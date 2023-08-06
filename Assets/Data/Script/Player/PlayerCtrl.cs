using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCtrl : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    [SerializeField] protected PlayerClimb playerClimb;
    public PlayerClimb PlayerClimb => playerClimb;

    [SerializeField] protected PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;

    [SerializeField] protected PlayerRespawn playerRespawn;
    public PlayerRespawn PlayerRespawn => playerRespawn;

    public int checkPoint;
    public bool isDead;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadPlayerClimb();
        this.LoadPlayerMove();
        this.LoadPlayerRespawn();
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

    protected virtual void LoadPlayerRespawn()
    {
        if(this.playerRespawn != null) return;
        this.playerRespawn = transform.GetComponentInChildren<PlayerRespawn>();
        Debug.Log(transform.name + ": LoadPlayerRespawn", transform.gameObject);
    }
}
