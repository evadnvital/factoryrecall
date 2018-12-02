using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepController : MonoBehaviour
{

    [SerializeField] private GameObject selector;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.currentCharacter == GameManager.Character.Beep)
        {
            selector.SetActive(true);

        }
        else if (GameManager.gameManager.currentCharacter != GameManager.Character.Beep)
        {
            selector.SetActive(false);
        }
    }
}
