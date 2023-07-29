using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HuyMonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float jump;

    private static InputManager instance;
    public static InputManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Update()
    {
        GetMoveInput();
    }

    protected virtual void GetMoveInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
    }
}
