using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject[] Scenes, vessels, levels, characters;
    public int scenesIndex = 0, vesselIndex=0, levelIndex=0, characterIndex=0;
  

    private void Start()
    {
        //Scenes = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Scenes[i] = transform.GetChild(i).gameObject;
        }
        foreach(GameObject go in Scenes)
        {
            go.SetActive(false);
        }
        if (Scenes[0])
        {
            Scenes[0].SetActive(true);
        }
    }
    public void NextScene()
    {
        Scenes[scenesIndex].SetActive(false);

        scenesIndex = (scenesIndex + 1) % Scenes.Length;
        Scenes[scenesIndex].SetActive(true);

    }
    public void PreviousScene()
    {
        Scenes[scenesIndex].SetActive(false);

        scenesIndex--;
        if (scenesIndex < 0)
        {
            scenesIndex = Scenes.Length - 1;
        }
        Scenes[scenesIndex].SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   

    public void NextVessel()
    {
        vessels[vesselIndex].SetActive(false);

        vesselIndex = (vesselIndex + 1) % vessels.Length;
        vessels[vesselIndex].SetActive(true);

    }
    public void PreviousVessel()
    {
        vessels[vesselIndex].SetActive(false);

        vesselIndex--;
        if (vesselIndex < 0)
        {
            vesselIndex = vessels.Length - 1;
        }
        vessels[vesselIndex].SetActive(true);

    }

    public void NextLevel()
    {
        levels[levelIndex].SetActive(false);

        levelIndex = (levelIndex + 1) % levels.Length;
        levels[levelIndex].SetActive(true);

    }
    public void PreviousLevel()
    {
        levels[levelIndex].SetActive(false);

        levelIndex--;
        if (levelIndex < 0)
        {
            levelIndex = levels.Length - 1;
        }
        levels[levelIndex].SetActive(true);

    }

    public void NextCharacter()
    {
        characters[characterIndex].SetActive(false);

        characterIndex = (characterIndex + 1) % characters.Length;
        characters[characterIndex].SetActive(true);

    }
    public void PreviousCharacter()
    {
        characters[characterIndex].SetActive(false);

        characterIndex--;
        if (characterIndex < 0)
        {
            characterIndex = characters.Length - 1;
        }
        characters[characterIndex].SetActive(true);

    }
    public void Confirm()
    {
        PlayerPrefs.SetInt("VesselSelected", vesselIndex);
        PlayerPrefs.SetInt("LevelSelected", levelIndex);
        PlayerPrefs.SetInt("CharacterSelected", characterIndex);
        
    }

    public void loadLevelScenes()
    {
        int levelSelected = PlayerPrefs.GetInt("LevelSelected");
        int vesselSelected = PlayerPrefs.GetInt("VesselSelected");
        int characterSelected = PlayerPrefs.GetInt("CharacterSelected");

        if (levelSelected == 0 && vesselSelected == 0 && characterSelected == 0)
        {
            SceneManager.LoadScene("LevelTest_1");
        }
        else if (levelSelected == 1 && vesselSelected == 1 && characterSelected == 1)
        {
            SceneManager.LoadScene("LevelTest_2");
        }
    }
}
