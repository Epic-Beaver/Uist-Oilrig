using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontColorChange : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerRight()
    {
        text.color = new Color(0, 180f / 255f, 0);
    }

    public void AnswerWrong()
    {
        text.color = Color.red;
    }
}
