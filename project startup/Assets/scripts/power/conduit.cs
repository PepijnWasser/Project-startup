using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conduit : MonoBehaviour
{
    public bool powered = false;
    public bool Activated = false;
    public Material matUnpowered;
    public Material matPowered;

    MeshRenderer renderer;

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (powered)
        {
            renderer.material = matPowered;
        }
        else
        {
            renderer.material = matUnpowered;
        }
    }
}
