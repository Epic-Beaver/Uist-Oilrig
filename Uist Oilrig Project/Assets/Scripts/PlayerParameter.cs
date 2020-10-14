using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//赋予特性(相当于锁脚本，这个脚本必须附在有CharacterController的物体上才能正常使用）
[RequireComponent(typeof(CharacterController))]

public class PlayerParameter : MonoBehaviour
{

    //定义参数
    [HideInInspector] //不在编辑器面板显示
    public Vector2 inputSmoothLook;
    [HideInInspector]
    public Vector2 inputMoveVector;
    [HideInInspector]
    public bool inputCrouch;
    [HideInInspector]
    public bool inputJump;
    [HideInInspector]
    public bool inputSprint;
    //[HideInInspector]
    //public bool inputFire;
    //[HideInInspector]
    //public bool inputReload;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
