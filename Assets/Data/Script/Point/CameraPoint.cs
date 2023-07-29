using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : HuyMonoBehaviour
{
    [SerializeField] protected Transform point;
    public Transform Point => point;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCameraPoint();
    }

    protected virtual void LoadCameraPoint()
    {
        if (this.point != null) return;
        this.point = GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadCameraPoint", transform.gameObject);
    }
}
