using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(menuName = "Ability/Shock")]
public class ShockBall : Ability
{
    public LayerMask layerMask;
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
            Collider2D collider = Physics2D.OverlapCircle(light.transform.position, light.transform.localScale.x / 2, layerMask);
            if (collider != null)
            {
                if (collider.gameObject.GetComponent<conduit>() != null)
                {
                    collider.gameObject.GetComponent<conduit>().Activated = true;     
                }
            }
        }
        else if(playingShockEffect)
        {
            secondCounter += Time.deltaTime;
            if (secondCounter > 2)
            {
                secondCounter = 0;
                playingShockEffect = false;
                CircleParticle.GetComponent<VisualEffect>().SetBool("activeLightning", false);
            }
        }
    }

    void ShowShockEffect()
    {
        CircleParticle.GetComponent<VisualEffect>().SetBool("activeLightning", true);
    }
}
