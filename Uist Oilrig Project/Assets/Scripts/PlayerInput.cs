using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    //隐藏鼠标光标
    public bool LockCursor
    {
        get { return Cursor.lockState == CursorLockMode.Locked ? true : false; } //如果光标处于锁定状态，则返回true
        set
        {
            Cursor.visible = value; //是否可见根据值设定
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

    private PlayerParameter parameter;
    private GameInput input;
    // Start is called before the first frame update
    void Start()
    {
        LockCursor = true;
        parameter = this.GetComponent<PlayerParameter>();
        input = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GameInput>();

    }

    private void InitialInput ()
    {
        parameter.inputMoveVector = new Vector2(input.GetAxis("Horizontal"), input.GetAxis("Vertical"));
        parameter.inputSmoothLook = new Vector2(input.GetAxisRaw("Mouse X"), input.GetAxisRaw("Mouse Y"));
        parameter.inputCrouch = input.GetButton("Crouch");
        parameter.inputJump = input.GetButton("Jumap");
        parameter.inputSprint = input.GetButton("Sprint");
        //parameter.inputFire = input.GetButton("Fire");
        //parameter.inputReload = input.GetButton("Reload");
    }

    // Update is called once per frame
    void Update()
    {
        InitialInput();
    }
}
