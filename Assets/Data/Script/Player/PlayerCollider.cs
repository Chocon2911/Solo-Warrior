using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCollider : HuyMonoBehaviour
{
    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    public CapsuleCollider2D CapsuleCollider => capsuleCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCollider", transform.gameObject);
    }
}
