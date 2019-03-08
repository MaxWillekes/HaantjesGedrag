using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPersonScript : MonoBehaviour
{
    public float attention;
    public float scared;
    public Animator animator;
    public int room;
    public bool gone = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (attention > 0) { attention -= Time.deltaTime; }
        if (scared > 0) { scared -= Time.deltaTime; }

        if (scared > 100)
        {
            //doe iets
        }

        animator.SetFloat("attention",attention);
        animator.SetFloat("scared", scared);

    }

    public void TriggerFunction(GameObject furniture)
    {
        objectScript furnitureScript = furniture.GetComponent<objectScript>();
        if (furnitureScript.room == room)
        {
            if (furnitureScript.attention)
            {
                attention = furnitureScript.attentionValue;
                scared += furnitureScript.scareValue;
            }
            else if (attention > 0 && !furnitureScript.used)
            {
                attention = furnitureScript.attentionValue;
                scared += furnitureScript.scareValue;
            }
        }
    }

}
