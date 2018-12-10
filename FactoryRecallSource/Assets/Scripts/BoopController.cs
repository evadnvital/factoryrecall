using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoopController : MonoBehaviour
{
    public static BoopController boopController { get; private set; }
    private bool moving;
    private Vector3 newPos;
    [SerializeField] private GameObject selector;
    public int energy = 5;
    private float speed = 2;

    private void Awake()
    {
        boopController = this;
    }

    // Use this for initialization
    void Start()
    {
        moving = false;
        energy = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameManager.PuzzleActive)
        {
            if (GameManager.gameManager.currentCharacter == GameManager.Character.Boop)
            {
                selector.SetActive(true);

                if (energy > 0)
                {
                    if (Input.GetKeyDown(KeyCode.Q) && !moving && transform.localPosition.x > -4)
                    {
                        newPos = new Vector3(transform.localPosition.x - 2, transform.localPosition.y, transform.localPosition.z);
                        moving = true;
                        StartCoroutine(MoveBoop(newPos));
                    }

                    if (Input.GetKeyDown(KeyCode.S) && !moving && transform.localPosition.x < 4)
                    {
                        newPos = new Vector3(transform.localPosition.x + 2, transform.localPosition.y, transform.localPosition.z);
                        moving = true;
                        StartCoroutine(MoveBoop(newPos));
                    }

                    if (Input.GetKeyDown(KeyCode.A) && !moving && transform.localPosition.z > -6)
                    {
                        newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 2);
                        moving = true;
                        StartCoroutine(MoveBoop(newPos));
                    }

                    if (Input.GetKeyDown(KeyCode.W) && !moving && transform.localPosition.z < 4)
                    {
                        newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);
                        moving = true;
                        StartCoroutine(MoveBoop(newPos));
                    }
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    BoopSpeed();
                }

            }
            else if (GameManager.gameManager.currentCharacter != GameManager.Character.Boop)
            {
                selector.SetActive(false);
            }
        }
    }

    IEnumerator MoveBoop(Vector3 pos)
    {
        float delta = 0;
        Vector3 initPos = transform.localPosition;

        while (delta <= 1)
        {
            transform.localPosition = Vector3.Lerp(initPos, pos, delta);

            delta += Time.deltaTime / speed;
            yield return null;
        }
        transform.localPosition = pos;
        moving = false;
        energy--;
        CanvasManager.canvasManager.UpdateEnergy();
    }

    private void BoopSpeed()
    {
        if (speed == 2.0f)
            speed = 0;
        else
            speed = 2.0f;
    }

}
