using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Door door;

    private void Start()
    {
        door = GameObject.FindObjectOfType<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoopController>())
        {
            this.GetComponent<Animator>().SetBool("isPressed", true);
            door.PressurePlateActivated = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BoopController>())
            door.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BoopController>())
        {
            this.GetComponent<Animator>().SetBool("isPressed", false);
        }
    }
}
