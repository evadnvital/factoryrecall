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

    public void Open()
    {
        //if level is resolved starts animation
        if (GameManager.gameManager.LevelResolved)
            GetComponent<Animator>().SetBool("levelResolved", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if Beep goes through door starts new level
        if (other.GetComponent<BeepController>())
        {
            GameManager.gameManager.LoadLevel();
        }
    }
}
