using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneManage : MonoBehaviour
{

    public bool firstPerson = false;

    public Animator anim;

    public void Start()
    {
        if (firstPerson)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Update()
    {
        if (firstPerson)
        {
            if (Input.GetAxisRaw("Fire2") > 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void SceneByName(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string levelName)
    {
        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
