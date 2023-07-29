using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : HuyMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    [SerializeField] protected float moveSpeed = 300f;
    public float MoveSpeed => moveSpeed;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected override void Update()
    {
        base.Update();
        this.StopMoving();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Moving();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }

    protected virtual void Moving()
    {
        if (!this.playerCtrl.PlayerClimb.stickedToRightWall && !this.playerCtrl.PlayerClimb.stickedToLeftWall)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                this.Move();
            }
        }
    }

    public virtual void Move()
    {
        this.playerCtrl.Rb2D.velocity = new Vector2(InputManager.Instance.horizontal * this.moveSpeed * Time.fixedDeltaTime, this.playerCtrl.Rb2D.velocity.y);
    }

    protected virtual void StopMoving()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            this.playerCtrl.Rb2D.velocity = new Vector2(0, this.playerCtrl.Rb2D.velocity.y);
        }
    }
}
