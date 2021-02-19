using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPushing : MonoBehaviour
{
    public string tag;

    public delegate void myPush(bool value);
    public static event myPush pushing;

    float secondCounter = 0;
    bool needToStop = true;

    private void Update()
    {
        if (needToStop)
        {
            secondCounter += Time.deltaTime;
            if(secondCounter > 0.25)
            {
                pushing?.Invoke(false);
            }
        }
        else
        {
            pushing?.Invoke(true);
            secondCounter = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == tag)
        {
            Debug.Log("appelflap");
            needToStop = false;
        }    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            needToStop = true;
        }
    }
}
