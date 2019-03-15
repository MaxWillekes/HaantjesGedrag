using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer ownSpriteRenderer;

    public float moveSpeed;    
    public GameObject furniture;

    public GameObject audio;

    public GameObject GameHandler;

    public Fungus.VariableReference CloseEnough;
    bool Close;
    public Fungus.VariableReference Interact;
    public Fungus.VariableReference InteractableCharacter;
    public Fungus.VariableReference RecentlySpoken;

    void Start()
    {
        Close = false;
        rb = GetComponent<Rigidbody2D>();
        ownSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        float inputHor = Input.GetAxisRaw("Horizontal");
        float inputVer = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(inputHor * moveSpeed, inputVer * moveSpeed);

        if (Input.GetKeyDown("space") && Close == true )
        {
            Interact.Set(true);
        }

        /*
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
        {
            if (furniture) {
                if (furniture.name == "Clock")
                {
                    audio.transform.Find("clock").GetComponent<AudioSource>().Pause();
                    audio.transform.Find("crazy_clock").GetComponent<AudioSource>().Play();
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
        */
    }

    void OnTriggerEnter2D(Collider2D collider) //trigger op meubel
    {
        InteractableCharacter.Set(collider.gameObject);
        CloseEnough.Set(true);
        Close = true;
    }

    void OnTriggerExit2D(Collider2D collider) //trigger op meubel
    {
        furniture = null;
        InteractableCharacter.Set(furniture);
        CloseEnough.Set(false);
        Interact.Set(false);
        Close = false;
        RecentlySpoken.Set(false);
    }
}