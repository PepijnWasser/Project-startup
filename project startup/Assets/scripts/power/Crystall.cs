using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystall : Conduit
{
    public float growTime;
    public float sizeMultiplier;
    Vector3 originalScale;
    Vector3 originalPosition;

    float currentGrowTime = 0;

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (powered)
        {
            renderer.material = matPowered;
            currentGrowTime += Time.deltaTime;
            var percentage = currentGrowTime / growTime;
            if(percentage > 1)
            {
                percentage = 1;
            }
            transform.localScale = originalScale + (percentage * (sizeMultiplier - 1) * originalScale);
            transform.position = originalPosition + new Vector3(0, (transform.localScale.y - originalScale.y) / 2, 0);
        }
        else
        {
            renderer.material = matUnpowered;
        }
    }
}