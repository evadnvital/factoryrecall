using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 newPos;
    private bool moving;
    private int direction;      //current movement direction
    private bool stopMoving;

    void Start()
    {
        //sets default variable values
        direction = 1;
        stopMoving = false;
    }

    void Update()
    {
        //check if game is running (not with a puzzle on screen)
        if (!GameManager.gameManager.PuzzleActive)
        {
            //checks if Enemy is not moving and cheat is not active
            if (!moving && !stopMoving)
            {
                //moves Enemy according to direction
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

                //sets Enemy as moving
                moving = true;
                //starts Enemy's movement
                StartCoroutine(Move(newPos));
            }
            //cheat code to stop Enemy from moving
            if (Input.GetKeyDown(KeyCode.C))
            {
                StopMoving();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //restarts the level if Enemy touches any of the characters
        if (other.GetComponent<BeepController>() || other.GetComponent<BoopController>())
        {
            GameManager.gameManager.RestartLevel();
        }
    }

    IEnumerator Move(Vector3 pos)
    {
        //creates Enemy's movement animation
        float time = 1f;
        float delta = 0;
        Vector3 initPos = transform.localPosition;

        while (delta <= 1)
        {
            //interpolates Enemy's movement
            transform.localPosition = Vector3.Lerp(initPos, pos, delta);

            delta += Time.deltaTime / time;
            yield return null;
        }

        //changes the direction
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

        yield return new WaitForSeconds(0.5f);
        //sets as not moving
        moving = false;
    }

    private void StopMoving()
    {
        //stops all movement
        stopMoving = !stopMoving;
    }
}
