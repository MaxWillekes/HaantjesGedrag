using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer ownSpriteRenderer;

    public float moveSpeed;
    public float calculationSpeed;

    public GameObject Interactable;

    public GameObject audio;

    public GameObject GameHandler;

    public Animator animation;
    public Sprite idleSprite;

    bool Close;

    public Fungus.Flowchart Flowchart;

    public bool scalingException = false;

    void Start()
    {
        Close = false;
        rb = GetComponent<Rigidbody2D>();
        ownSpriteRenderer = GetComponent<SpriteRenderer>();

        Flowchart = GameObject.Find("GameHandler").GetComponent<Fungus.Flowchart>();
    }

    public void Update()
    {
        float inputHor = Input.GetAxisRaw("Horizontal");
        float inputVer = Input.GetAxisRaw("Vertical");

        //Debug.Log("Hor =" + inputHor + "   |   Ver =" + inputVer);
        if (scalingException == true)
        {
            rb.velocity = new Vector2(inputHor * moveSpeed, inputVer * moveSpeed);
        }else{
            var actualMoveSpeed = ((calculationSpeed / (transform.position.y / 1.5f)) + moveSpeed);

            //Scales the player speed to the Y position of thier character
            rb.velocity = new Vector2(inputHor * actualMoveSpeed, inputVer * actualMoveSpeed);

            //Scales the player size according to the Y position of thier character.
            transform.localScale = new Vector3(0.165f - (transform.position.y / 112), 0.165f - (transform.position.y / 112), 0.165f - (transform.position.y / 112));
        }


        if (inputHor > 0 || inputVer > 0 || inputHor < 0 || inputVer < 0)
        {
            animation.enabled = true;
        }else{
            animation.enabled = false;
            ownSpriteRenderer.sprite = idleSprite;
        }

        if (inputHor < 0){
            ownSpriteRenderer.flipX = true;
        }else if (inputHor > 0){
            ownSpriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown("space") && Close == true)
        {
            Flowchart.SetBooleanVariable("Interact", true);
        }

        if(SceneManager.GetActiveScene().name == "Bar")
        {
            Flowchart.SetBooleanVariable("InBar", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Interactable = collider.gameObject;
        if(Interactable.name == "en_street_bd_bar")
        {
            SceneManager.LoadScene("Bar");
        }else{
            Flowchart.SetGameObjectVariable("InteractableCharacter", Interactable);
            Flowchart.SetBooleanVariable("CloseEnough", true);
            Close = true;

            var emission = Interactable.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        var emission = Interactable.GetComponent<ParticleSystem>().emission;
        emission.enabled = false;

        Interactable = null;
        Flowchart.SetGameObjectVariable("InteractableCharacter", Interactable);
        Flowchart.SetBooleanVariable("CloseEnough", false);
        Flowchart.SetBooleanVariable("Interact", false);
        Close = false;
        Flowchart.SetBooleanVariable("RecentlySpoken", false);
    }
}