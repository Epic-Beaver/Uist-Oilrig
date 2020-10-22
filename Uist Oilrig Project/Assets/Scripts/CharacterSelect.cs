using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSel( int character)
    {
        switch (character)
        {
            case 1: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            case 2: SceneManager.LoadScene("OilRigSample_AddPlayerMovement"); break;
            default: break;
        }
    }
}
