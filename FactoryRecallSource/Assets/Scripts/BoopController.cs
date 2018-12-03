﻿using System.Collections;
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
                    StartCoroutine(MoveBoop(newPos));
                }

                if (Input.GetKeyDown(KeyCode.S) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x + 2, transform.localPosition.y, transform.localPosition.z);
                    moving = true;
                    StartCoroutine(MoveBoop(newPos));
                }

                if (Input.GetKeyDown(KeyCode.A) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 2);
                    moving = true;
                    StartCoroutine(MoveBoop(newPos));
                }

                if (Input.GetKeyDown(KeyCode.W) && !moving)
                {
                    newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);
                    moving = true;
                    StartCoroutine(MoveBoop(newPos));
                }
            }

        }
        else if (GameManager.gameManager.currentCharacter != GameManager.Character.Boop)
        {
            selector.SetActive(false);
        }

    }

    IEnumerator MoveBoop(Vector3 pos)
    {
        float time = 2;
        float delta = 0;
        Vector3 initPos = transform.localPosition;

        while (delta <= 1)
        {
            transform.localPosition = Vector3.Lerp(initPos, pos, delta);

            delta += Time.deltaTime / time;
            yield return null;
        }
        --energy;
        transform.localPosition = pos;
        moving = false;
    }

}
