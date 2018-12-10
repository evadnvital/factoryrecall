using System.Collections;
using UnityEngine;

public class BoopController : MonoBehaviour
{
    public static BoopController boopController { get; private set; }
    private bool moving;                                                //checks if Boop is moving
    private Vector3 newPos;                                             //Boop's target position
    [SerializeField] private GameObject selector;
    public int energy = 5;                                              //Boop's energy
    private float speed = 2;                                            //Boop's movement speed

    private void Awake()
    {
        //allows other scripts to access the Beep Controller
        boopController = this;
    }

    void Start()
    {
        //sets default variable values
        moving = false;
        energy = 5;
    }

    void Update()
    {
        //check if game is running (not with a puzzle on screen)
        if (!GameManager.gameManager.PuzzleActive)
        {
            //check if current controlled character is Boop
            if (GameManager.gameManager.currentCharacter == GameManager.Character.Boop)
            {
                //shows current controlled character indicator
                selector.SetActive(true);

                //checks if Boop has energy
                if (energy > 0)
                {
                    //checks if Boop is not moving
                    if (!moving)
                    {
                        //moves Boop
                        if (Input.GetKeyDown(KeyCode.Q) && transform.localPosition.x > -4)
                        {
                            newPos = new Vector3(transform.localPosition.x - 2, transform.localPosition.y, transform.localPosition.z);

                            //sets Boop as moving
                            moving = true;
                            //starts Boop's movement
                            StartCoroutine(MoveBoop(newPos));
                        }
                        if (Input.GetKeyDown(KeyCode.S) && transform.localPosition.x < 4)
                        {
                            newPos = new Vector3(transform.localPosition.x + 2, transform.localPosition.y, transform.localPosition.z);

                            //sets Boop as moving
                            moving = true;
                            //starts Boop's movement
                            StartCoroutine(MoveBoop(newPos));
                        }
                        if (Input.GetKeyDown(KeyCode.A) && transform.localPosition.z > -6)
                        {
                            newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 2);

                            //sets Boop as moving
                            moving = true;
                            //starts Boop's movement
                            StartCoroutine(MoveBoop(newPos));
                        }
                        if (Input.GetKeyDown(KeyCode.W) && transform.localPosition.z < 4)
                        {
                            newPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);

                            //sets Boop as moving
                            moving = true;
                            //starts Boop's movement
                            StartCoroutine(MoveBoop(newPos));
                        }
                    }
                }
                //cheat code for Boop speed
                if (Input.GetKeyDown(KeyCode.V))
                {
                    BoopSpeed();
                }

            }
            //check if current controlled character is not Boop
            else if (GameManager.gameManager.currentCharacter != GameManager.Character.Boop)
            {
                //removes current controlled character indicator
                selector.SetActive(false);
            }
        }
    }

    IEnumerator MoveBoop(Vector3 pos)
    {
        //creates Boop's movement animation
        float delta = 0;
        Vector3 initPos = transform.localPosition;

        while (delta <= 1)
        {
            //interpolates Boop's movement
            transform.localPosition = Vector3.Lerp(initPos, pos, delta);

            delta += Time.deltaTime / speed;
            yield return null;
        }
        //sets Boop's position to target position
        transform.localPosition = pos;
        //sets as not moving
        moving = false;
        //expends 1 energy and updates canvas
        energy--;
        CanvasManager.canvasManager.UpdateEnergy();
    }

    private void BoopSpeed()
    {
        //sets Boop's movement speed as instant
        if (speed == 2.0f)
            speed = 0;
        else
            speed = 2.0f;
    }

}
