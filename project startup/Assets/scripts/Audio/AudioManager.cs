using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceShock;
    public AudioSource audioSourceMoving;
    bool needToPlayShock;
    public bool needToPlayMoving = false;


    private void OnEnable()
    {
        ShockBall.OnShockBallPlaying += UpdateShock;
        PlayerController.moving += UpdateMoving;
    }

    private void OnDisable()
    {
        ShockBall.OnShockBallPlaying -= UpdateShock;
        PlayerController.moving -= UpdateMoving;
    }

    void Update()
    {
        if (needToPlayShock)
        {
            if (!audioSourceShock.isPlaying)
            {
                audioSourceShock.Play();
            }
        }
        else
        {
            if (audioSourceShock.isPlaying)
            {
                audioSourceShock.Stop();
            }
        }

        if (needToPlayMoving)
        {
            if (!audioSourceMoving.isPlaying)
            {
                audioSourceMoving.Play();
            }
        }
        else
        {
            if (audioSourceMoving.isPlaying)
            {
                audioSourceMoving.Stop();
            }
        }

    }

    void UpdateShock(bool value)
    {
        needToPlayShock = value;
    }

    void UpdateMoving(bool value)
    {
        Debug.Log(value);
        needToPlayMoving = value;
    }
}
