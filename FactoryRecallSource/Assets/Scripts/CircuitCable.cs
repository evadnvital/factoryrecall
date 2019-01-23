using System.Collections;
using UnityEngine;

public class CircuitCable : MonoBehaviour
{
    private bool isCharging;

    void Start()
    {
        //sets default variable values
        isCharging = false;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BoopController>() != null)
        {
            //while Boop is on cables sets as charging
            isCharging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BoopController>() != null)
        {
            //if Boop leaves cables stop charging
            isCharging = false;
        }
    }

    public void StartCharge()
    {
        //calls for charging
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
                    //charges Boop's energy by 1 each 1 second and updates canvas
                    yield return new WaitForSeconds(1f);
                    ++BoopController.boopController.energy;
                    //CanvasManager.canvasManager.UpdateEnergy();
                    BoopController.boopController.Battery();
                }
                else
                {
                    //if Boop's energy is 5 then doesn't increase further
                    BoopController.boopController.energy = 5;
                    yield return null;
                }
            }
            else yield return null;
        }
    }
}
