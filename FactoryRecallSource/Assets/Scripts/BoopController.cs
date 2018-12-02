using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoopController : MonoBehaviour
{

    private bool moving;
    private Vector3 newPos;
    [SerializeField] private GameObject selector;
    public int energy = 5;

    // Use this for initialization
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.currentCharacter == GameManager.Character.Boop)
        {
            selector.SetActive(true);

            if (energy > 0)
            {
                if (Input.GetKeyDown(KeyCode.Q) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x - 2, transform.localPosition.y, transform.localPosition.z);
                    moving = true;
                    StartCoroutine(MoveBoop());
                }

                if (Input.GetKeyDown(KeyCode.S) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x + 2, transform.localPosition.y, transform.localPosition.z);
                    moving = true;
                    StartCoroutine(MoveBoop());
                }

                if (Input.GetKeyDown(KeyCode.A) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 2);
                    moving = true;
                    StartCoroutine(MoveBoop());
                }

                if (Input.GetKeyDown(KeyCode.W) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);
                    moving = true;
                    StartCoroutine(MoveBoop());
                }
            }

        }
        else if (GameManager.gameManager.currentCharacter != GameManager.Character.Boop)
        {
            selector.SetActive(false);
        }

    }

    IEnumerator MoveBoop()
    {
        transform.localPosition = newPos;
        energy--;
        yield return new WaitForSeconds(2f);
        moving = false;
    }

}
