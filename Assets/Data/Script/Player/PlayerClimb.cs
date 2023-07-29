using UnityEngine;

public class PlayerClimb : HuyMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] protected float climbHeight = 2;
    [SerializeField] protected Transform RightWallCheck;
    [SerializeField] protected Transform LeftWallCheck;
    [SerializeField] protected LayerMask groundLayer; 
    public bool stickedToRightWall;
    public bool stickedToLeftWall;


    protected override void Update()
    {
        base.Update();
        stickedToRightWall = Physics2D.OverlapCapsule(RightWallCheck.position, new Vector2(0f, 0.6f), CapsuleDirection2D.Vertical,0, groundLayer);
        stickedToLeftWall = Physics2D.OverlapCapsule(LeftWallCheck.position, new Vector2(0f, 0.6f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.CheckIfStickedToWall();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected virtual void Climbing()
    {
        this.playerCtrl.Rb2D.velocity = new Vector2(playerCtrl.Rb2D.velocity.x, this.climbHeight);
    }

    protected virtual void MoveOutWall()
    {
        this.playerCtrl.PlayerMove.Move();
    }
    protected virtual void CheckIfStickedToWall()
    {
        if (!this.stickedToRightWall || !this.stickedToLeftWall)
        {
            this.playerCtrl.Rb2D.gravityScale = 10f;
        }

        if(this.stickedToRightWall)
        {
            this.playerCtrl.Rb2D.velocity = Vector2.zero;
            this.playerCtrl.Rb2D.gravityScale = 0;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                this.Climbing();
            }
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
                this.MoveOutWall();
            }
        }
        if (this.stickedToLeftWall)
        {
            this.playerCtrl.Rb2D.velocity = Vector2.zero;
            this.playerCtrl.Rb2D.gravityScale = 0;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
                this.Climbing();
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                this.MoveOutWall();
            }
        }
    }
}
