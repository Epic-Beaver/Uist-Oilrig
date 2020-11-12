using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractButton : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public Image icon;
    public string sceneName;
    public GameObject toDoList;
    public GameObject miniGame;

    private Vector3 imagePos;
    private Vector3 screenCentre;


    // Start is called before the first frame update
    void Start()
    {
        screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
        imagePos = new Vector3(1000, 1000, 0);
        if (this.gameObject.name == "InteractButton")
        {
            this.gameObject.SetActive(false);
            icon.enabled = false;
            icon.GetComponentInChildren<Text>().enabled = false;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        print(this.gameObject.name);
        imagePos = cam.WorldToScreenPoint(transform.position);
        if (imagePos.z > 0 && Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            icon.enabled = true;
            icon.GetComponentInChildren<Text>().enabled = true;

            if (Input.GetAxisRaw("Interact") > 0)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (this.gameObject.name == "LifeVest")
                    {
                        toDoList.transform.Find("1").GetComponent<Text>().color = Color.grey;
                    }
                    else if (this.gameObject.name == "SafetyHat")
                    {
                        toDoList.transform.Find("2").GetComponent<Text>().color = Color.grey;
                    }
                    this.gameObject.SetActive(false);
                    icon.enabled = false;
                    icon.GetComponentInChildren<Text>().enabled = false;
                }

                if (toDoList.transform.Find("1").GetComponent<Text>().color == Color.grey && toDoList.transform.Find("2").GetComponent<Text>().color == Color.grey)
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
        } else
        {
            icon.enabled = false;
            icon.GetComponentInChildren<Text>().enabled = false;
            imagePos = new Vector3(1000, 1000, 0);
        }

        icon.transform.position = imagePos;

    }
}
