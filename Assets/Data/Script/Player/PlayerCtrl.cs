using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCtrl : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    public CapsuleCollider2D CapsuleCollider => capsuleCollider;

    [SerializeField] protected PlayerClimb playerClimb;
    public PlayerClimb PlayerClimb => playerClimb;

    [SerializeField] protected PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
        this.LoadPlayerClimb();
        this.LoadPlayerMove();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb2D != null) return;
        this.rb2D = GetComponent<Rigidbody2D>();
        this.rb2D.isKinematic = false;
        this.rb2D.gravityScale = 50f;
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadCollider()
    {
        if(this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", transform.gameObject);
    }

    protected virtual void LoadPlayerClimb()
    {
        if(this.playerClimb != null) return;
        this.playerClimb = transform.GetComponentInChildren<PlayerClimb>();
        Debug.Log(transform.name + ": LoadPlayerClimb", transform.gameObject);
    }

    protected virtual void LoadPlayerMove()
    {
        if(this.playerMove != null) return;
        this.playerMove = transform.GetComponentInChildren<PlayerMove>();
        Debug.Log(transform.name + ": LoadPlayerMove", transform.gameObject);
    }
}
