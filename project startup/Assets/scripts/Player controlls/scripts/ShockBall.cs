using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Shock")]
public class ShockBall : Ability
{
    public LayerMask layerMask;

    public override void HandleAbility(GameObject player, GameObject light)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D collider = Physics2D.OverlapCircle(light.transform.position, light.transform.localScale.x / 2, layerMask);
            if (collider != null)
            {
                if (collider.gameObject.GetComponent<conduit>() != null)
                {
                    collider.gameObject.GetComponent<conduit>().Activated = true;
                }
            }
        }
    }
}
