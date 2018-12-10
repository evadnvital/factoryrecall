using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Vector3 newPos;
    private bool moving;
    private int direction;
    private bool stopMoving;

    // Use this for initialization
    void Start()
    {
        direction = 1;
        stopMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameManager.PuzzleActive)
        {
            if (!moving && !stopMoving)
            {
                if (direction == 1)
                {
                    newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);
                }

                if (direction == 2)
                {
                    newPos = new Vector3(transform.localPosition.x - 2, transform.localPosition.y, transform.localPosition.z);
                }

                if (direction == 3)
                {
                    newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 2);
                }

                if (direction == 4)
                {
                    newPos = new Vector3(transform.localPosition.x + 2, transform.localPosition.y, transform.localPosition.z);
                }
                moving = true;
                StartCoroutine(Move(newPos));
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                StopMoving();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BeepController>() || other.GetComponent<BoopController>())
        {
            GameManager.gameManager.RestartLevel();
        }
    }

    IEnumerator Move(Vector3 pos)
    {
        float time = 1.5f;
        float delta = 0;
        Vector3 initPos = transform.localPosition;

        while (delta <= 1)
        {
            transform.localPosition = Vector3.Lerp(initPos, pos, delta);

            delta += Time.deltaTime / time;
            yield return null;
        }

        if (transform.position.z >= 3 && direction == 1)
        {
            direction = 2;
            transform.position = new Vector3(transform.position.x, transform.position.y, 4);
        }
        if (transform.localPosition.x <= -3 && direction == 2)
        {
            direction = 3;
            transform.localPosition = new Vector3(-4, transform.position.y, transform.position.z);
        }
        if (transform.position.z <= -5 && direction == 3)
        {
            direction = 4;
            transform.position = new Vector3(transform.position.x, transform.position.y, -6);
        }
        if (transform.localPosition.x >= 1 && direction == 4)
        {
            direction = 1;
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }
        else
            transform.position = pos;

        yield return new WaitForSeconds(1);
        moving = false;
    }

    private void StopMoving()
    {
        stopMoving = !stopMoving;
    }
}
