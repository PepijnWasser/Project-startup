using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public bool needToPlay;
    public GameObject obj;

    void Update()
    {
        needToPlay = obj.GetComponent<VisualEffect>().GetBool("activeLightning");
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
}
