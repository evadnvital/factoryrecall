using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitCable : MonoBehaviour
{
    private bool isCharging;

    // Use this for initialization
    void Awake()
    {
        isCharging = false;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BoopController>() != null)
        {
            isCharging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BoopController>() != null)
        {
            isCharging = false;
        }
    }

    public void StartCharge()
    {
        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        while (true)
        {
            if (isCharging)
            {
                if (BoopController.boopController.energy < 5)
                {
                    yield return new WaitForSeconds(1f);
                    ++BoopController.boopController.energy;
                    CanvasManager.canvasManager.UpdateEnergy();
                }
                else
                {
                    BoopController.boopController.energy = 5;
                    yield return null;
                }
            }
            else yield return null;
        }
    }
}
