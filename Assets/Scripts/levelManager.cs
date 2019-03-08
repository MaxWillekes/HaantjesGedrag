using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

    public GameObject audio;

    public void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (Application.loadedLevelName == "Home")
            {
                audio.GetComponent<AudioSource>().Play();
                Application.LoadLevel("tutorialScreen1");
            }
            else if (Application.loadedLevelName == "tutorialScreen1")
            {
                audio.GetComponent<AudioSource>().Play();
                Application.LoadLevel("tutorialScreen2");
            }
            else if (Application.loadedLevelName == "tutorialScreen2")
            {
                audio.GetComponent<AudioSource>().Play();
                Application.LoadLevel("level0");
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (Application.loadedLevelName == "Home")
            {
                audio.GetComponent<AudioSource>().Play();
                Application.Quit();
            }
            else if (Application.loadedLevelName == "level1")
            {
                audio.GetComponent<AudioSource>().Play();
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        
    }

    public void NextTutorialScreen1()
    {
        audio.GetComponent<AudioSource>().Play();
        Application.LoadLevel("tutorialScreen1");
    }

    public void NextTutorialScreen2()
    {
        audio.GetComponent<AudioSource>().Play();
        Application.LoadLevel("tutorialScreen2");
    }

    public void loadLevel()
    {
        audio.GetComponent<AudioSource>().Play();
        Application.LoadLevel("level0");
    }

    public void RedoLevel()
    {
        audio.GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void back () {
        audio.GetComponent<AudioSource>().Play();
        Application.LoadLevel ("Home");
	}

    public void credits()
    {
        audio.GetComponent<AudioSource>().Play();
        Application.LoadLevel("Credits");
    }

    public void exit () {
        audio.GetComponent<AudioSource>().Play();
        Application.Quit();
	}
}