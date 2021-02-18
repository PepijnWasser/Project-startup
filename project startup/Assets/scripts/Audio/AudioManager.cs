using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public bool needToPlay;
    public GameObject obj;

    private void OnEnable()
    {
        ShockBall.OnShockBallPlaying += UpdateSound;
    }

    private void OnDisable()
    {
        ShockBall.OnShockBallPlaying -= UpdateSound;
    }

    void Update()
    {
        if (needToPlay)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

        }
    }

    void UpdateSound(bool value)
    {
        needToPlay = value;
    }
}
