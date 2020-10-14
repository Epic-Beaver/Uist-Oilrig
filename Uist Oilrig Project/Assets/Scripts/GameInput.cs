using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    //用于存储自定义轴的信息
    public class InputAxis
    {
        public KeyCode positive;
        public KeyCode negative;

    }

    //定义按键集合
    public Dictionary<string, KeyCode> buttons = new Dictionary<string, KeyCode>();
    //定义自定义轴的集合
    public Dictionary<string, InputAxis> axis = new Dictionary<string, InputAxis>();

    //用集合存储unity自带的轴
    public List<string> unityAxis = new List<string>();


    //添加按钮
    private void AddButton(string n, KeyCode k)
    {
        if (buttons.ContainsKey(n))
            buttons[n] = k;
        else
            buttons.Add(n, k);
    }

    //添加自定义轴
    private void AddAxis(string n, KeyCode pk, KeyCode nk)
    {
        if (axis.ContainsKey(n))
            axis[n] = new InputAxis() { positive = pk, negative = nk };
        else
            axis.Add(n, new InputAxis() { positive = pk, negative = nk });
    }

    //添加unity轴
    private void AddUnityAxis(string n)
    {
        if (!unityAxis.Contains(n))
            unityAxis.Add(n);
    }


    //初始化默认值
    private void SetupDefaults(string type="")
    {
        if (type == "" || type == "buttons")
        {
            if (buttons .Count == 0)
            {
                //AddButton("Fire", KeyCode.Mouse0);       //开火
                //AddButton("Reload", KeyCode.R);          //装弹
                AddButton("Jump", KeyCode.Space);        //跳跃
                AddButton("Crouch", KeyCode.C);          //蹲下
                AddButton("Sprint", KeyCode.LeftShift);  //疾跑
            }
        }

        if (type == "" || type == "Axis")
        {
            if (axis.Count == 0)
            {
                AddAxis("Horizontal", KeyCode.W, KeyCode.S);
                AddAxis("Vertical", KeyCode.A, KeyCode.D);
            }
        }

        if (type == "" || type == "UnityAxis")
        {
            if (unityAxis.Count == 0)
            {
                AddUnityAxis("Mouse X");
                AddUnityAxis("Mouse Y");
                AddUnityAxis("Horizontal");
                AddUnityAxis("Vertical");
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        SetupDefaults();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //外界获取按键
    public bool GetButton(string button)
    {
        if (buttons.ContainsKey(button))
            return Input.GetKey(buttons[button]);
        return false;
    }

    public bool GetButtonDown(string button) 
    {
        if (buttons.ContainsKey(button))
            return Input.GetKeyDown(buttons[button]);
        return false;
    }

    //获取轴，轴的范围在-1到1之间
    public float GetAxis(string axis)
    {
        if (this.unityAxis.Contains(axis))
            return Input.GetAxis(axis);
        else
            return 0;
    }
    
    //AxisRaw只有三个值-1，0，1
    public float GetAxisRaw(string axis)
    {
        if (this.axis.ContainsKey(axis))
        {
            float val = 0;
            if (Input.GetKey(this.axis[axis].positive))
                return 1;
            if (Input.GetKey(this.axis[axis].negative))
                return -1;
            return val;
        }

        else if (unityAxis.Contains(axis))
        {
            return Input.GetAxisRaw(axis);
        }
        else
        {
            return 0;
        }
    }


}
