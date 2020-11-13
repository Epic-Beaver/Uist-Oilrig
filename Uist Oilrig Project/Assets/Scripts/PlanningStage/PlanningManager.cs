using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanningManager : MonoBehaviour
{
    public GameObject[] Icons,Scenes;
    public static int slotOccupoied;
    [SerializeField]
    private Transform[] options;
    [SerializeField]
    private GameObject wrongSign;

    private void Start()
    {
        Drag.PuzzleDone += CheckResults;
        slotOccupoied = 0;
    }
    public void CheckResults()
    {
        if(options[0].position.y == 114 && options[1].position.y == 41 && options[2].position.y == -26.5 && options[3].position.y == -106 && options[4].position.y == -180 && options[5].position.y == -256)
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
        Drag.PuzzleDone -= CheckResults;
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
    public void ChangeScenes1()
    {

        Scenes[2].SetActive(false);
        Scenes[3].SetActive(true);
    }
    public void Finish()
    {
        SceneManager.LoadScene("BuildStart");
    }
  
   


}
