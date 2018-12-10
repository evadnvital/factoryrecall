using UnityEngine;

public class BeepController : MonoBehaviour
{
    public static BeepController beepController { get; private set; }
    [SerializeField] private GameObject selector;
    
    void Awake()
    {
        //allows other scripts to access the Beep Controller
        beepController = this;
    }
    
    void Update()
    {
        //check if game is running (not with a puzzle on screen)
        if (!GameManager.gameManager.PuzzleActive)
        {
            //check if current controlled character is Beep
            if (GameManager.gameManager.currentCharacter == GameManager.Character.Beep)
            {
                //shows current controlled character indicator
                selector.SetActive(true);

                //moves Beep
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
            //check if current controlled character is not Beep
            else if (GameManager.gameManager.currentCharacter != GameManager.Character.Beep)
            {
                //removes current controlled character indicator
                selector.SetActive(false);
            }
        }
    }
}
