using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Expand")]
public class ExpandBall : Ability
{
    public float expandMultiplier = 2;
    public float scaleTime = 0.5f;
    private float currentScaleTime = 0;

    bool expendAnimation = false;
    public Vector3 originalScale;

    public override void HandleAbility(GameObject player, GameObject light)
    {
        if (Input.GetKeyDown(KeyCode.R) && !expendAnimation)
        {
            expendAnimation = true;
        }
        if (expendAnimation)
        {
            currentScaleTime += Time.deltaTime;
            float percentage = currentScaleTime / scaleTime;
            float val = Mathf.Sin(percentage * Mathf.PI);
            float multiplier = val * expandMultiplier;
            if (val > 1)
            {
                val = 1;
            }

            light.transform.localScale = originalScale + new Vector3(1, 1, 1) * multiplier;

            if (percentage > 1)
            {
                expendAnimation = false;
                currentScaleTime = 0;
            }
        }
        else
        {
             light.transform.localScale = originalScale;
        }
    }
}
