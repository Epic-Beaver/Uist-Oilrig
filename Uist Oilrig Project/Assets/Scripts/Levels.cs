using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelection( int level)
    {
        switch (level)
        {
            case 1: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            case 2: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            case 3: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            case 4: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            case 5: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            case 6: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            //case 7: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            default:  break;
        }
    }
}
