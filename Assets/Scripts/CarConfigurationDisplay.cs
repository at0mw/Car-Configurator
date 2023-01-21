using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarConfigurationDisplay : MonoBehaviour
{
    [SerializeField]private CarConfiguration carConfiguration;
    [SerializeField]private TMP_Dropdown colourDropdown;
    [SerializeField] private TMP_Dropdown engineDropdown;
    [SerializeField] private TMP_Dropdown interiorStyleDropdown;

    private void Start()
    {
        Debug.Log("setting values");
        colourDropdown.value = (int)carConfiguration.colour;
        engineDropdown.value = (int)carConfiguration.engine;
        interiorStyleDropdown.value = (int)carConfiguration.interiorStyle;
    }
}
