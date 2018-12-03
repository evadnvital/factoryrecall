using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private Text energyLevel;
    [SerializeField] private BoopController boopController;

    // Use this for initialization
    void Start()
    {
        boopController = FindObjectOfType<BoopController>();
    }

    // Update is called once per frame
    void Update()
    {
        energyLevel.text = boopController.energy.ToString();
    }
}
