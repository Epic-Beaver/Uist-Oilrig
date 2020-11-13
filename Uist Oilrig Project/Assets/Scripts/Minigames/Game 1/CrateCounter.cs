using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrateCounter : MonoBehaviour
{
    public UnityEvent gameSuccess;
    public int crateNumber;
    private int currentCrates;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCrates >= crateNumber && !gameOver)
        {
            gameSuccess.Invoke();
            Debug.Log("Conglaturations");
            gameOver = true;
        }
    }

    public void increaseNumber()
    {
        currentCrates++;
        Debug.Log("Job's a good 'un");
    }

    public void decreaseNumber()
    {
        currentCrates--;
        Debug.Log("Job's a bad 'un");
    }
}
