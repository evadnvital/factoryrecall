using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepController : MonoBehaviour
{
    public static BeepController beepController { get; private set; }
    [SerializeField] private GameObject selector;

    // Use this for initialization
    void Awake()
    {
        beepController = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameManager.PuzzleActive)
        {
            if (GameManager.gameManager.currentCharacter == GameManager.Character.Beep)
            {
                selector.SetActive(true);

                if (Input.GetKey(KeyCode.Q) )
                {
                    transform.localPosition = new Vector3(transform.localPosition.x - 0.1f, transform.localPosition.y, transform.localPosition.z);
                }

                if (Input.GetKey(KeyCode.S) )
                {
                    transform.localPosition = new Vector3(transform.localPosition.x + 0.1f, transform.localPosition.y, transform.localPosition.z);
                }

                if (Input.GetKey(KeyCode.A) )
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.1f);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.1f);
                }

            }
            else if (GameManager.gameManager.currentCharacter != GameManager.Character.Beep)
            {
                selector.SetActive(false);
            }
        }
    }
}
