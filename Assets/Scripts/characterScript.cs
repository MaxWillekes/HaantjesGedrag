using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer ownSpriteRenderer;

    public float waitTimer;

    public float moveSpeed;    
    public GameObject furniture;

    public GameObject[] People;
    public GameObject audio;
    public float time;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ownSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float inputHor = Input.GetAxisRaw("Horizontal");
        float inputVer = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(inputHor * moveSpeed, inputVer * moveSpeed);

        if (Input.GetKeyDown("space")/* || Input.GetButtonDown("Fire1")*/)
        {
            if (furniture) {
                if (!furniture.GetComponent<objectScript>().used || furniture.GetComponent<objectScript>().attention)
                {
                    waitTimer = 1;
                    rb.simulated = false;
                    ownSpriteRenderer.enabled = false;
                    var animation = furniture.GetComponent<Animation>();

                    foreach (GameObject Person in People)
                    {
                        Person.GetComponent<tutorialPersonScript>().TriggerFunction(furniture);
                    }

                    furniture.GetComponent<objectScript>().used = true;
                }

                if (furniture.name == "Clock")
                {
                    audio.transform.Find("clock").GetComponent<AudioSource>().Pause();
                    audio.transform.Find("crazy_clock").GetComponent<AudioSource>().Play();
                    time = Time.time;
                }
                if (furniture.name == "Lamp")
                {
                    audio.transform.Find("lamp").GetComponent<AudioSource>().Play();
                }
                if(furniture.name == "Cabinet")
                {
                    audio.transform.Find("cabinet").GetComponent<AudioSource>().Play();
                }
                if (furniture.name == "Chair")
                {
                    audio.transform.Find("Chair").GetComponent<AudioSource>().Play();
                }
                if (furniture.name == "TV")
                {
                    audio.transform.Find("TV").GetComponent<AudioSource>().Play();
                }
                if (furniture.name == "Bookcase")
                {
                    audio.transform.Find("Pot").GetComponent<AudioSource>().Play();
                }
                if (furniture.name == "Painting wall")
                {
                    audio.transform.Find("Painting").GetComponent<AudioSource>().Play();
                }
                if (furniture.name == "Painting ground")
                {
                    audio.transform.Find("Painting fall").GetComponent<AudioSource>().Play();
                }
                

            }
        }

        try
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
                furniture.GetComponent<Animator>().enabled = true;
                furniture.GetComponent<Animator>().SetBool("Triggerd", true);
            }
            else if (!ownSpriteRenderer.enabled)
            {
                rb.simulated = true;
                ownSpriteRenderer.enabled = true;
            }
            else if (waitTimer <= 0)
            {
                furniture.GetComponent<Animator>().SetBool("Triggerd", false);

            }
        }
        catch { }

    }

    void OnTriggerEnter2D(Collider2D collider) //trigger op meubel
    {
        furniture = collider.gameObject;
        if (!furniture.GetComponent<objectScript>().used || furniture.GetComponent<objectScript>().attention)
        {
            var emission = furniture.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) //trigger op meubel
    {
        var emission = furniture.GetComponent<ParticleSystem>().emission;
        emission.enabled = false;
        furniture = null;        
    }
}
