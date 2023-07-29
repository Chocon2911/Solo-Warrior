using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class MoveCameraToPoint : HuyMonoBehaviour
{
    [SerializeField] protected float transitionTime = 2f;

    [SerializeField] protected EdgeCollider2D edgeCollider;
    public EdgeCollider2D EdgeCollider => edgeCollider;

    [SerializeField] protected CameraPoint cameraPoint;

    [SerializeField] protected GameObject mainCamera;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadCamera();
        this.LoadCameraPoint();
    }

    protected virtual void LoadCameraPoint()
    {
        if (this.cameraPoint != null) return;
        this.cameraPoint = transform.parent.GetComponent<CameraPoint>();
        Debug.Log(transform.name + ": LoadCameraPoint", transform.gameObject);
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Camera");
        Debug.Log(transform.name + ": LoadCamera", transform.gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.edgeCollider != null) return;
        this.edgeCollider = GetComponent<EdgeCollider2D>();
        this.edgeCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", transform.gameObject);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.mainCamera.transform.position = Vector3.Lerp(this.mainCamera.transform.position, this.cameraPoint.Point.position, this.transitionTime);
        }
    }
}
