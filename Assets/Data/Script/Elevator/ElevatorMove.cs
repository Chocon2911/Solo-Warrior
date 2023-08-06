using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorMove : HuyMonoBehaviour
{
    [SerializeField] protected ElevatorCtrl elevatorCtrl;
    public ElevatorCtrl ElevatorCtrl => elevatorCtrl;

    [SerializeField] protected float pointDistance;
    [SerializeField] protected int index = 0;
    [SerializeField] protected float speed;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadElevatorCtrl();
    }

    protected override void Update()
    {
        base.Update();
        this.PointMoving();
        this.NextPointCalculate();
    }

    protected virtual void LoadElevatorCtrl()
    {
        if (this.elevatorCtrl != null) return;
        this.elevatorCtrl = gameObject.GetComponentInParent<ElevatorCtrl>();
        Debug.Log(transform.name + ": LoadElevatorCtrl", transform.gameObject);
    }
    protected virtual void PointLerpMoving()
    {
        float lerpSpeed = 1f;;
        transform.position = Vector3.Lerp(transform.position, this.CurrentPoint().position, lerpSpeed);
    }

    protected virtual void PointMoving()
    {
        float step = this.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, this.CurrentPoint().position, step);
    }

    protected virtual void NextPointCalculate()
    {
        this.pointDistance = Vector2.Distance(transform.position, this.CurrentPoint().position);
        if (this.pointDistance == 0) this.index++;
        if(this.index >= this.elevatorCtrl.PointPrefab.Count) this.index = 0;
    }

    public virtual Transform CurrentPoint()
    {
        return this.elevatorCtrl.PointPrefab[this.index];
    }
}
