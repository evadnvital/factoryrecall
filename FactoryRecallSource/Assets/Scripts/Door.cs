using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool pressurePlateActivated;
    public bool PressurePlateActivated
    {
        get
        {
            return pressurePlateActivated;
        }

        set
        {
            pressurePlateActivated = value;
        }
    }

    // Update is called once per frame
    public void Open()
    {
        if (GameManager.gameManager.LevelResolved)
            GetComponent<Animator>().SetBool("levelResolved", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BeepController>())
        {
            GameManager.gameManager.LoadLevel();
        }
    }

}
