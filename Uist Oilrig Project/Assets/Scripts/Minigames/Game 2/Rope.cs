using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rope : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public Image icon;
    public GameObject ropeBefore;
    public GameObject ropeAfter;


    public string sceneName;
    public GameObject toDoList;
    public GameObject miniGame;

    private Vector3 imagePos;
    // Start is called before the first frame update
    void Start()
    {
        imagePos = new Vector3(1000, 1000, 0);
        icon.enabled = false;
        icon.GetComponentInChildren<Text>().enabled = false;
        if (this.gameObject.activeSelf)
            ropeAfter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        imagePos = cam.WorldToScreenPoint(transform.position);
        icon.transform.position = imagePos;
        if (imagePos.z > 0 && Vector3.Distance(player.transform.position, transform.position) < 4)
        {
            icon.enabled = true;
            icon.GetComponentInChildren<Text>().enabled = true;

            if (Input.GetAxisRaw("Interact") > 0)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ropeBefore.SetActive(false);
                    ropeAfter.SetActive(true);
                    icon.enabled = false;
                    icon.GetComponentInChildren<Text>().enabled = false;
                    toDoList.transform.Find("3").GetComponent<Text>().color = Color.grey;
                }
            }
        } else
        {
            icon.enabled = false;
            icon.GetComponentInChildren<Text>().enabled = false;
            imagePos = new Vector3(1000, 1000, 0);
        }

        if (toDoList.transform.Find("3").GetComponent<Text>().color == Color.grey)
        {
            if (!miniGame.activeSelf)
                miniGame.SetActive(true);
            toDoList.transform.Find("4").GetComponent<Text>().color = Color.black;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
