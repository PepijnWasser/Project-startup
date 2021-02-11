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

    public override void HandleAbility(GameObject player, GameObject light)
    {
        CircleParticle = GameObject.Find("CircleEffect");
        Debug.Log(CircleParticle);
        if (Input.GetKeyDown(KeyCode.E))
        {
            CircleParticle.GetComponent<VisualEffect>().SetBool("activeLightning", true);
            Collider2D collider = Physics2D.OverlapCircle(light.transform.position, light.transform.localScale.x / 2, layerMask);
            if (collider != null)
            {
                if (collider.gameObject.GetComponent<conduit>() != null)
                {
                    collider.gameObject.GetComponent<conduit>().Activated = true;
                    
                    
                }
            }
        }
        else
        {
            secondCounter += Time.deltaTime;
            if (secondCounter > 2)
            {
                secondCounter = 0;
                CircleParticle.GetComponent<VisualEffect>().SetBool("activeLightning", false);
            }
        }
    }
}
