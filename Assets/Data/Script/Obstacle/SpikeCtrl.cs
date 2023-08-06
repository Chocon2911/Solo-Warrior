using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SpikeCtrl : HuyMonoBehaviour
{
    [SerializeField] protected PolygonCollider2D obstacleCollider;
    public PolygonCollider2D ObstacleCollider => obstacleCollider;

    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] protected Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb2D != null) return;
        this.rb2D = GetComponent<Rigidbody2D>();
        this.rb2D.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadCollider()
    {
        if(this.obstacleCollider != null) return;
        this.obstacleCollider = GetComponent<PolygonCollider2D>();
        this.obstacleCollider.isTrigger = false;
        Debug.Log(transform.name + ": LoadCollider", transform.gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if(this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.playerCtrl.isDead = true;
        }
    }
}
