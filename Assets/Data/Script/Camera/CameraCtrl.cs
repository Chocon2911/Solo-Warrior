using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : HuyMonoBehaviour
{
    [SerializeField] protected GameObject mainCamera;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.Find("Main Camera");
        Debug.Log(transform.name + ": LoadMainCamera", transform.gameObject);
    }
}
