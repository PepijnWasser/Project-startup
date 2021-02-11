using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Composite")]
public class CompositeAbility : Ability
{
    public Ability[] abilities;

    public override void HandleAbility(GameObject player, GameObject light)
    {
        if (abilities.Length != 0)
        {
            foreach (Ability ability in abilities)
            {
                ability.HandleAbility(player, light);
            }
        }
    }
}
