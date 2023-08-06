using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RespawnCtrl : HuyMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider;
    public BoxCollider2D BoxCollider => boxCollider;

    [SerializeField] protected PlayerCtrl playerCtrl;

    [SerializeField] protected Transform position;
    public Transform Position => position;

    [SerializeField] protected int checkPoint;
    [SerializeField] protected bool isActivated;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadPlayerCtrl();
        this.LoadPosition();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", transform.gameObject);
    }

    protected virtual void LoadPosition()
    {
        if(this.position != null) return;
        this.position = gameObject.GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadPosition", transform.gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.isActivated = true;
            if(this.playerCtrl.checkPoint < this.checkPoint)
            {
                this.playerCtrl.checkPoint = this.checkPoint;
                this.playerCtrl.PlayerRespawn.respawnPosition = this.position;
            }
        }
    }
}
