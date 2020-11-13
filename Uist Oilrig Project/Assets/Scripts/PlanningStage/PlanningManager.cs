﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanningManager : MonoBehaviour
{
    public GameObject[] Icons, Scenes, box;
    [SerializeField]
    private Transform[] options;
    [SerializeField]
    private GameObject wrongSign;
    
   

    private void Start()
    {

    }
    void Update()
    {

        if (options[0].position.x == box[0].transform.position.x && options[1].position.x == box[1].transform.position.x && options[2].position.x == box[2].transform.position.x && options[3].position.x == box[3].transform.position.x && options[4].position.x == box[4].transform.position.x && options[5].position.x == box[5].transform.position.x)
        {
            Debug.Log("success");
            CheckResults();
        }



    }


    public void CheckResults()
    {
        Debug.Log("check");


        if (options[0].position == box[0].transform.position && options[1].position == box[1].transform.position && options[2].position == box[2].transform.position && options[3].position == box[3].transform.position && options[4].position == box[4].transform.position && options[5].position == box[5].transform.position)
        {
            Scenes[2].SetActive(false);
            Scenes[3].SetActive(true);
            Debug.Log("win");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Win()
    {
        if (Icons[0].activeSelf == true && Icons[2].activeSelf == true && Icons[3].activeSelf == true && Icons[5].activeSelf == true && Icons[6].activeSelf == true && Icons[9].activeSelf == true)
        {
            Scenes[0].SetActive(false);

            Scenes[1].SetActive(true);

        }
    }
    public void ChangeScenes()
    {

        Scenes[1].SetActive(false);
        Scenes[2].SetActive(true);
    }
    public void Finish()
    {
        SceneManager.LoadScene("BuildStart");
    }




}
