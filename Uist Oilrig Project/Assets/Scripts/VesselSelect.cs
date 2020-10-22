using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VesselSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VesselSel( int Vessel)
    {
        switch (Vessel)
        {
            case 1: SceneManager.LoadScene("OilRigCharacterSelect"); break;
            case 2: SceneManager.LoadScene("OilRigCharacterSelect"); break;
            default: break;
        }
    }
}
