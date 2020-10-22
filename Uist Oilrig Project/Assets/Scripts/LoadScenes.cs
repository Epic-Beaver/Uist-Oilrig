using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadStartScene();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("OilRigStart");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("OilRigCredits");
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("OilRigLevelSelect");
    }
}
