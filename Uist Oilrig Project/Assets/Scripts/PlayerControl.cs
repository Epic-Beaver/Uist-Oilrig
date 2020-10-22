using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//定义枚举，通过枚举来表示玩家的状态
public enum PlayerState
{
    None,
    Idle,
    Walk,
    Crouch,
    Run,
}


public class PlayerControl : MonoBehaviour
{

    private PlayerState state = PlayerState.None;
    public PlayerState State
    {
        get
        {
            if (running)
                state = PlayerState.Run;
            else if (walking)
                state = PlayerState.Walk;
            else if (crouching)
                state = PlayerState.Crouch;
            else
                state = PlayerState.Idle;
            return state;
        }
    }

    public float sprintSpeed = 10.0f;
    public float sprintJumpSpeed = 8.0f;
    public float normalSpeed = 6.0f;
    public float normalJumpSpeed = 7.0f;
    public float crouchSpeed = 2.0f;
    public float crouchJumpSpeed = 5.0f;
    public float crouchDeltaHeight = 0.5f; //玩家蹲伏变量，在玩家蹲伏时会下降0.5

    public float gravity = 20.0f;
    public float cameraMoveSpeed = 8.0f;
    public AudioClip jumpAudio;

    //玩家状态
    private float speed; //玩家当前速度
    private float jumpSpeed;
    private Transform mainCamera;
    private float standardCamHeight;
    private float crouchingCamHeight;
    private bool grouded = false; //判断玩家是否在地面上
    private bool walking = false;
    private bool crouching = false;
    //private bool stopCrouching = false;
    private bool running = false;
    //控制器正常情况下的高度
    private Vector3 normalControllerCenter = Vector3.zero;
    private float normalControllerHeight = 0.0f;
    
    
    //private float timer = 0;
    private CharacterController controller;
    private AudioSource audioSource;
    private PlayerParameter parameter;
    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        crouching = false;
        walking = false;
        running = false;
        speed = normalSpeed;
        jumpSpeed = normalJumpSpeed;
        mainCamera = GameObject.FindGameObjectWithTag(Tags.mainCamera).transform;
        standardCamHeight = mainCamera.localPosition.y;
        crouchingCamHeight = standardCamHeight - crouchDeltaHeight;
        audioSource = this.GetComponent<AudioSource>();
        controller = this.GetComponent<CharacterController>();
        parameter = this.GetComponent<PlayerParameter>();
        normalControllerCenter = controller.center;
        normalControllerHeight = controller.height;

    }

    private void UpdateMove()
    {
        if (grouded)
        {
            moveDirection = new Vector3(parameter.inputMoveVector.x, 0, parameter.inputMoveVector.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (parameter.inputJump)
            {
                moveDirection.y = jumpSpeed;
                AudioSource.PlayClipAtPoint(jumpAudio, transform.position);
                CurrentSpeed();
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        grouded = (flags & CollisionFlags.CollidedBelow) != 0; //说明与地面接触了

        if (Mathf.Abs(moveDirection.x) > 0 && grouded || Mathf.Abs(moveDirection.z) > 0 && grouded) //如果有按键输入
        {
            if (parameter.inputSprint)
            {
                walking = false;
                running = true;
                crouching = false;
            }
            else if (parameter.inputCrouch )
            {
                crouching = true;
                running = false;
                walking = false;
            }
            else
            {
                crouching = false;
                running = false;
                walking = true;
            }
        }
        else
        {
            if (walking)
                walking = false;
            if (running)
                running = false;
            if (parameter.inputCrouch)
                crouching = true;
            else
                crouching = false;
        }

        if (crouching)
        {
            controller.height = normalControllerHeight - crouchDeltaHeight;
            controller.center = normalControllerCenter - new Vector3(0, crouchDeltaHeight / 2, 0);
        }
        else
        {
            controller.height = normalControllerHeight;
            controller.center = normalControllerCenter;
        }

        UpdateCrouch();
        CurrentSpeed();

    }


    private void CurrentSpeed()
    {
        switch (State) {
            case PlayerState.Idle:
                speed = normalSpeed;
                jumpSpeed = normalJumpSpeed;
                break;
            case PlayerState.Walk:
                speed = normalSpeed;
                jumpSpeed = normalJumpSpeed;
                break;
            case PlayerState.Crouch:
                speed = crouchSpeed;
                jumpSpeed = crouchJumpSpeed;
                break;
            case PlayerState.Run:
                speed = sprintSpeed;
                jumpSpeed = sprintJumpSpeed;
                break;
        }
    }

    private void AudioManagement ()
    {
        if (State == PlayerState.Walk)
        {
            audioSource.pitch = 1.0f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (State == PlayerState.Run)
        {
            audioSource.pitch = 1.3f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();
    }

    //是否蹲伏对相机的封装
    private void UpdateCrouch()
    {
        if (crouching)
        {
            if (mainCamera.localPosition.y > crouchingCamHeight)
            {
                if (mainCamera.localPosition.y - (crouchDeltaHeight * Time.deltaTime * cameraMoveSpeed) < crouchingCamHeight)
                    mainCamera.localPosition = new Vector3(mainCamera.localPosition.x, crouchingCamHeight, mainCamera.localPosition.z);
                else
                    mainCamera.localPosition -= new Vector3(0, crouchDeltaHeight * Time.deltaTime * cameraMoveSpeed, 0);
            }
            else
                mainCamera.localPosition = new Vector3(mainCamera.localPosition.x, crouchingCamHeight, mainCamera.localPosition.z);
        }
        else
        {
            if (mainCamera.localPosition.y < standardCamHeight)
            {
                if (mainCamera.localPosition.y + (crouchDeltaHeight * Time.deltaTime * cameraMoveSpeed) > standardCamHeight)
                    mainCamera.localPosition = new Vector3(mainCamera.localPosition.x, standardCamHeight, mainCamera.localPosition.z);
                else
                    mainCamera.localPosition += new Vector3(0, crouchDeltaHeight * Time.deltaTime * cameraMoveSpeed, 0);
            }
            else
                mainCamera.localPosition = new Vector3(mainCamera.localPosition.x, standardCamHeight, mainCamera.localPosition.z);
        }
    }


    private void FixedUpdate()
    {
        UpdateMove();
        AudioManagement();
    }
}
