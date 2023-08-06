using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : HuyMonoBehaviour
{
    public Transform respawnPosition;

    [SerializeField] PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected override void Update()
    {
        base.Update();
        this.IsDie();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = gameObject.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }

    protected virtual void IsDie()
    {
        if (!this.playerCtrl.isDead) return;
        this.playerCtrl.Rb2D.simulated = false;
        this.playerCtrl.transform.position = this.respawnPosition.position;
        this.playerCtrl.isDead = false;
        StartCoroutine(Respawn(0.2f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration); 
        this.playerCtrl.Rb2D.simulated = true;
    }
}
