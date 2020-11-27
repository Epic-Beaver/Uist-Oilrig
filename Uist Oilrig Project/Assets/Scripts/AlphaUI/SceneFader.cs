using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fader;
    public Text desc;
    public float speed = 0.5f;
    public float totalTime = 5;

    private  float time = 0;
    private float alpha;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 1;
        fader.color = new Color(58f / 255f, 58f / 255f, 58f / 255f, alpha);
        desc.color = new Color(255, 255, 255, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > totalTime)
        {
            if (alpha >= 0)
            {
                alpha -= Time.deltaTime * speed;
                fader.color = new Color(58f / 255f, 58f / 255f, 58f / 255f, alpha);
                desc.color = new Color(255, 255, 255, alpha);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }


    }

}
