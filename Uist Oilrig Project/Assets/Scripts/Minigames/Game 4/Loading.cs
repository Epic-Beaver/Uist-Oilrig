using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    //进度条 image
    public Image process_Image;
    //显示的进度文字 100%
    public Text process_Text;
    public Text icon;

    //控制进度
    float CurProgressValue = 0;
    float ProgressValue = 100;

    private bool isStart = false;

    private void Start()
    {
        icon.enabled = false;
        process_Image.enabled = false;
    }
    void Update()
    {
        if(isStart)
        {
            if (CurProgressValue < ProgressValue)
            {
                CurProgressValue++;
            }
            //实时更新进度百分比的文本显示 
            process_Text.text = CurProgressValue + "%";
            //实时更新滑动进度图片的fillAmount值  
            process_Image.GetComponent<Image>().fillAmount = CurProgressValue / 100f;
            if (CurProgressValue == 100)
            {
                process_Text.text = "Finish";
                icon.enabled = true;
            }
        }
    }

    public void ProgressStart()
    {
        process_Image.enabled = true;
        isStart = true;
    }
}
