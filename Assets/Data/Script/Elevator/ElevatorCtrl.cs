using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ElevatorCtrl : HuyMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider;
    public BoxCollider2D BoxCollider => boxCollider;

    [SerializeField] protected Rigidbody2D rb2D;
    public Rigidbody2D Rb2D => rb2D;

    [SerializeField] protected List<Transform> pointPrefab;
    public List<Transform> PointPrefab => pointPrefab;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
        this.LoadWayPoint();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": Loadcollider", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if(this.rb2D != null) return;
        this.rb2D = GetComponent<Rigidbody2D>();
        this.rb2D.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadWayPoint()
    {
        if(this.pointPrefab.Count > 0) return;
        Transform wayPoint = transform.parent.transform.Find("WayPoint").GetComponentInChildren<Transform>();
        foreach(Transform point in wayPoint)
        {
            this.pointPrefab.Add(point);
        }
        Debug.Log(transform.name + ": LoadWayPoint", transform.gameObject);
    }
}
