using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    public void UIEnable()
    {
        GameObject.Find("Scene/StartMenu/Button").SetActive(true);
    }
}
