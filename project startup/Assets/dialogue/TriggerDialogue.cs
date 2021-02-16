using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public string tag;
    public dialogueManager[] dialogueManagers;
    public int[] toWhatNumber;


    private void Start()
    {
        if(dialogueManagers.Length != toWhatNumber.Length)
        {
            Debug.LogError("values are not equal");
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == tag)
        {
            Debug.Log("Player");
            for (int i = 0; i < dialogueManagers.Length; i++)
            {
                dialogueManagers[i].PlayUntil(toWhatNumber[i]);
            }
        }
    }
}
