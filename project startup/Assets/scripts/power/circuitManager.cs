using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circuitManager : MonoBehaviour
{
    public conduit[] connectedConduits;
    public bool powered = false;
    float secondCounter = 0;

    private void Update()
    {
        checkTime();
        if (powered == true)
        {
            PowerCircuit();
        }
        else
        {
            UnPowerCircuit();
        }
        CheckActivation();
    }

    void checkTime()
    {
        secondCounter += Time.deltaTime;
        if(secondCounter > 2)
        {
            secondCounter = 0;
            powered = false;
        }
    }

    void CheckActivation()
    {
        if (connectedConduits.Length != 0)
        {
            foreach (conduit conduit in connectedConduits)
            {
                if (conduit.Activated)
                {
                    powered = true;
                    secondCounter = 0;
                    conduit.Activated = false;
                }             
            }
        }
    }

    void PowerCircuit()
    {
        if(connectedConduits.Length != 0)
        {
            foreach(conduit conduit in connectedConduits)
            {
                conduit.powered = true;
            }
        }
    }

    void UnPowerCircuit()
    {
        if (connectedConduits.Length != 0)
        {
            foreach (conduit conduit in connectedConduits)
            {
                conduit.powered = false;
            }
        }
    }


    public void Power()
    {
        powered = true;
    }
}
