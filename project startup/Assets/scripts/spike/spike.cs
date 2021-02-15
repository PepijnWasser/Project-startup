using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public string tag;
    public ResetLevel restartLevel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == tag)
        {
            Debug.Log("Player");
            restartLevel.RegenerateLevel();
        }
    }
}
