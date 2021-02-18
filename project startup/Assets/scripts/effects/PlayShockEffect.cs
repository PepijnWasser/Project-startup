using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayShockEffect : MonoBehaviour
{

    private void OnEnable()
    {
        ShockBall.OnShockBallPlaying += UpdateEffect;
    }

    private void OnDisable()
    {
        ShockBall.OnShockBallPlaying -= UpdateEffect;
    }

    void UpdateEffect(bool value)
    {
        GetComponent<VisualEffect>().SetBool("activeLightning", value);
    }

}
