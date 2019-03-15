using System.Collections;
using System.Collections.Generic;
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

        //Debug.Log("Hor =" + inputHor + "   |   Ver =" + inputVer);
        var actualMoveSpeed = ((calculationSpeed / (transform.position.y / 1.5f)) + moveSpeed);

        //Scales the player speed to the Y position of thier character
        rb.velocity = new Vector2(inputHor * actualMoveSpeed, inputVer * actualMoveSpeed);

        if(inputHor > 0 || inputVer > 0 || inputHor < 0 || inputVer < 0){
            animation.enabled = true;
        }else{
            animation.enabled = false;
            ownSpriteRenderer.sprite = idleSprite;
        }

        if(inputHor < 0){
            ownSpriteRenderer.flipX = true;
        }else if(inputHor > 0){
            ownSpriteRenderer.flipX = false;
        }

        //Scales the player size according to the Y position of thier character.
        transform.localScale = new Vector3(0.165f - (transform.position.y / 112), 0.165f - (transform.position.y / 112), 0.165f - (transform.position.y / 112));

        if (Input.GetKeyDown("space") && Close == true ){
            Interact.Set(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Interactable = collider.gameObject;

        InteractableCharacter.Set(Interactable);
        CloseEnough.Set(true);
        Close = true;

        var emission = Interactable.GetComponent<ParticleSystem>().emission;
        emission.enabled = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        var emission = Interactable.GetComponent<ParticleSystem>().emission;
        emission.enabled = false;

        Interactable = null;
        InteractableCharacter.Set(Interactable);
        CloseEnough.Set(false);
        Interact.Set(false);
        Close = false;
        RecentlySpoken.Set(false);
    }
}