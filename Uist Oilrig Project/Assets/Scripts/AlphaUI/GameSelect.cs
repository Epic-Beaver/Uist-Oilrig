using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSelect : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
        //intro.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //鼠标悬停时播放音效
    public void OnPointerEnter(PointerEventData eventData)
    {
        //transform.localScale = new Vector3(1.05f, 1.2f, 1);

        Button button = this.gameObject.GetComponent<Button>();
        if (button == null)
            return;
        sound.pitch = 1.0f;
        if (!sound.isPlaying)
            sound.Play();
    }

    public void ButtonLarge()
    {
        transform.localScale = new Vector3(1.05f, 1.2f, 1);
    }
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    print("exit");
    //    transform.localScale = new Vector3(1, 1, 1);
    //}
}
