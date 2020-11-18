using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlanningManager : MonoBehaviour
{
    public GameObject[] Icons, Scenes, box;
    [SerializeField]
    private Transform[] options, initialPosition;
    [SerializeField]
    private GameObject wrongSign;
    public CamShake CamShake;

    void Update()
    {

        if (options[0].position.x == box[0].transform.position.x && options[1].position.x == box[1].transform.position.x && options[2].position.x == box[2].transform.position.x && options[3].position.x == box[3].transform.position.x && options[4].position.x == box[4].transform.position.x && options[5].position.x == box[5].transform.position.x)
        {
            Debug.Log("CheckResultssuccess");
            CheckResults();
        }



    }


    public void CheckResults()
    {
        Debug.Log("check");


        if (options[0].position == box[0].transform.position && options[1].position == box[1].transform.position && options[2].position == box[2].transform.position && options[3].position == box[3].transform.position && options[4].position == box[4].transform.position && options[5].position == box[5].transform.position)
        {
            Scenes[3].SetActive(false);
            Scenes[4].SetActive(true);
            Debug.Log("rightorder");
        }
        else
        {
            Debug.Log("lost");

            wrongSign.SetActive(true);

            Invoke("ReloadGame", 1f);
        }
    }
    public void ReloadGame()
    {
        wrongSign.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            options[i].position = initialPosition[i].position;
        }
    }
    public void Win()
    {
        if (Icons[0].activeSelf == true && Icons[2].activeSelf == true && Icons[3].activeSelf == true && Icons[5].activeSelf == true && Icons[6].activeSelf == true && Icons[9].activeSelf == true)
        {
            Debug.Log("win");
            Scenes[1].SetActive(false);

            Scenes[2].SetActive(true);

        }
    }
    public void Finish()
    {
        SceneManager.LoadScene("BuildStart");
    }




}
