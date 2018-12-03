using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitCable : MonoBehaviour
{
    private BoopController boopController;
    private bool isCharging;

    // Use this for initialization
    void Start()
    {
        boopController = FindObjectOfType<BoopController>();
        isCharging = false;
        StartCoroutine(Charge());
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

    IEnumerator Charge()
    {
        while (true)
        {
            if (isCharging)
            {
                if (boopController.energy < 5)
                {
                    yield return new WaitForSeconds(1f);
                    boopController.energy++;
                }
                else
                {
                    boopController.energy = 5;
                    yield return null;
                }
            }
            else yield return null;
        }
    }
}
