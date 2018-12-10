using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Door door;

    private void Start()
    {
        //finds Door in game
        door = GameObject.FindObjectOfType<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoopController>())
        {
            //if Boop is on the plate starts animation and sets plate as active
            this.GetComponent<Animator>().SetBool("isPressed", true);
            door.PressurePlateActivated = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //while Boop is on plate checks if Door can open
        if (other.GetComponent<BoopController>())
            door.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BoopController>())
        {
            //if Boop leaves plate starts animation
            this.GetComponent<Animator>().SetBool("isPressed", false);
        }
    }
}
