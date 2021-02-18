using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(menuName = "Ability/Shock")]
public class ShockBall : Ability

{
    public delegate void myEvent(bool needToPlay);
    public static event myEvent OnShockBallPlaying;


    public LayerMask layerMask;
    public AudioManager audioManager;

    GameObject CircleParticle;
    float secondCounter = 0;
    bool playingShockEffect = false;

    public override void HandleAbility(GameObject player, GameObject light)
    {
        CircleParticle = GameObject.Find("CircleEffect");
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowShockEffect();
            playingShockEffect = true;
        }
        if(playingShockEffect)
        {
            Collider2D collider = Physics2D.OverlapCircle(light.transform.position, light.transform.localScale.x / 2, layerMask);
            if (collider != null)
            {
                if (collider.gameObject.GetComponent<Conduit>() != null)
                {
                    collider.gameObject.GetComponent<Conduit>().Activated = true;
                }
            }
            secondCounter += Time.deltaTime;
            if (secondCounter > 2)
            {
                secondCounter = 0;
                playingShockEffect = false;
                HideShockEffect();
            }
        }
    }

    void ShowShockEffect()
    {
        CircleParticle.GetComponent<VisualEffect>().SetBool("activeLightning", true);
        OnShockBallPlaying?.Invoke(true);
    }

    void HideShockEffect()
    {
        OnShockBallPlaying?.Invoke(false);
        CircleParticle.GetComponent<VisualEffect>().SetBool("activeLightning", false);
    }
}
