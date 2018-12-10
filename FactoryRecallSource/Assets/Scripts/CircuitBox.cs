using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBox : MonoBehaviour
{

    public enum Color
    {
        Blue, Green
    }

    public Color color;
    public bool isConnected;
    [SerializeField] private GameObject circuit;

    // Use this for initialization
    void Start()
    {
        circuit.SetActive(false);
        isConnected = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BeepController>())
        {
            if (Input.GetKey(KeyCode.E))
            {
                CanvasManager.canvasManager.PopUpPuzzle(color.ToString());
            }
        }
    }

    public void TurnOn()
    {
        if (color == Color.Blue && GameManager.gameManager.BlueCircuitResolved)
        {
            isConnected = true;
            circuit.SetActive(true);
            circuit.GetComponent<CircuitCable>().StartCharge();
        }
        else if (color == Color.Green && GameManager.gameManager.GreenCircuitResolved)
        {
            isConnected = true;
            circuit.SetActive(true);
            circuit.GetComponent<CircuitCable>().StartCharge();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            StartCoroutine(TurnOff());
        }
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(1f);

        isConnected = false;
        circuit.SetActive(false);
        if (color == Color.Blue)
        {
            GameManager.gameManager.BlueCircuitResolved = false;
        }
        else if (color == Color.Green)
        {
            GameManager.gameManager.GreenCircuitResolved = false;
        }
    }
}
