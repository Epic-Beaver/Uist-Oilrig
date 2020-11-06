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

    private Vector3 imagePos;
    private Vector3 screenCentre;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
        imagePos = new Vector3(1000, 1000, 0);
    }

    // Update is called once per frame
    void Update()
    {

        imagePos = cam.WorldToScreenPoint(transform.position);
        if (imagePos.z > 0 && Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            icon.enabled = true;
            icon.GetComponentInChildren<Text>().enabled = true;

            if (Input.GetAxisRaw("Interact") > 0)
            {
                StartCoroutine(LoadLevel(sceneName));
            }
        } else
        {
            icon.enabled = false;
            icon.GetComponentInChildren<Text>().enabled = false;
            imagePos = new Vector3(1000, 1000, 0);
        }

        icon.transform.position = imagePos;

    }

    IEnumerator LoadLevel(string levelName)
    {
        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
