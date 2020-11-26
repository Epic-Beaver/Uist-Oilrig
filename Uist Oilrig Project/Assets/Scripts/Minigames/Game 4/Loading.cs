using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour
{

    //进度条 image
    public Image process_Image;
    public TextMeshProUGUI taskText;
    //显示的进度文字 100%
    public TextMeshProUGUI process_Text;
    public Image icon;
    public Sprite completedIcon;
    public bool complete;
    public Color finishedColor;

    //控制进度
    float CurProgressValue = 0;
    float ProgressValue = 100;

    private bool isStart = false;

    void Update()
    {
        if(isStart)
        {
            if (CurProgressValue < ProgressValue)
            {
                CurProgressValue++;
            }
            //实时更新进度百分比的文本显示 
            //process_Text.text = CurProgressValue + "%";
            //实时更新滑动进度图片的fillAmount值  
            process_Image.GetComponent<Image>().fillAmount = CurProgressValue / 100f;

            if (CurProgressValue == 100)
            {
                process_Text.text = "Done";
                taskText.color = finishedColor;
                icon.sprite = completedIcon;
                complete = true;
            }
        }
    }

    public void ProgressStart()
    {
        process_Image.enabled = true;
        isStart = true;
    }
}
