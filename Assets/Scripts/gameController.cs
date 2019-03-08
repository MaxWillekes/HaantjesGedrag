using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public float time;
    float current_time;
    public Transform timerBar;
    public GameObject[] People;
    public GameObject[] HUDS;
    public GameObject personHUD;
    public GameObject audio;
    public GameObject Redo;
    public GameObject RedoRuntime;
    public GameObject Player;
    int fled = 0;

    void Start()
    {
        HUDS = new GameObject[People.Length];
        for (int i = 0; i < People.Length; i++)
        {
            HUDS[i] = GameObject.Instantiate(personHUD);
        }
        Debug.Log(HUDS[0]);
    }

    void Update()
    {
        current_time -= Time.deltaTime;
        if (Application.loadedLevelName == "level0")
        {
            timerBar.position = new Vector3((time - current_time) / time * -18f, -4.7f, 0f);
        }
        else
        {
            timerBar.position = new Vector3((time - current_time) / time * -18f + Player.transform.position.x, -4.7f + Player.transform.position.y, -4f);
        }

        for (int i = 0; i < People.Length; i++)
        {
            HUDS[i].transform.position = new Vector3(People[i].transform.position.x, People[i].transform.position.y + 2f, 0);

            var personScript = People[i].GetComponent<tutorialPersonScript>();
            HUDS[i].active = personScript.attention > 0;
            HUDS[i].transform.Find("Neutral_Smiley").gameObject.active = personScript.scared <= 0;
            HUDS[i].transform.Find("Nervous_Smiley").gameObject.active = personScript.scared < 60 && personScript.scared > 0;
            HUDS[i].transform.Find("Panick_Smiley").gameObject.active = personScript.scared > 99;

            HUDS[i].transform.Find("AttentionBar").localScale = new Vector3(-0.2f * (personScript.attention / 7), HUDS[i].transform.Find("AttentionBar").localScale.y, 1);
            HUDS[i].transform.Find("AttentionBar").position = new Vector3(People[i].transform.position.x - 0.6f * ((7 - personScript.attention) / 7), HUDS[i].transform.Find("AttentionBar").position.y, HUDS[i].transform.Find("AttentionBar").position.z);

            if(Application.loadedLevelName == "level0")
            {
                if (personScript.attention > 0)
                {
                    audio.transform.Find("music").GetComponent<AudioSource>().Pause();
                }
                else if (!audio.transform.Find("music").GetComponent<AudioSource>().isPlaying)
                {
                    audio.transform.Find("music").GetComponent<AudioSource>().Play();
                }
            }
            if (personScript.scared > 100 && !personScript.gone)
            {
                audio.transform.Find("scream").GetComponent<AudioSource>().Play();
                personScript.gone = true;
            }

        }
        /*
        if (Redo.active)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (Application.loadedLevelName == "level0")
                {
                    Time.timeScale = 1;
                    Application.LoadLevel("Home");
                }
            }
        } else if (!Redo.active)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (Application.loadedLevelName == "level0")
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }*/
    }

    void FixedUpdate()
    {
        if (current_time < 0)
        {
            Time.timeScale = 0;
            Redo.active = true;
            RedoRuntime.active = false;
        }


    }


}
