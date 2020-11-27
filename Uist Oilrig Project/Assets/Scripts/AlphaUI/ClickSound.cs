using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadStartScene();
    }

    //鼠标悬停时播放音效
    public void OnPointerEnter(PointerEventData eventData)
    {

        Button button = this.gameObject.GetComponent<Button>();
        if (button == null)
            return;
        sound.pitch = 1.0f;
        if (!sound.isPlaying)
            sound.Play();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }


}
