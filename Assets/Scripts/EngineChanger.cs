using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EngineChanger : MonoBehaviour
{
    public TMP_Dropdown engineDropdown;
    public enum Engine
    {
        Street,
        Racing
    }
    public Engine EngineSelected;
    public Material[] EngineMaterial;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        engineDropdown = GameObject.Find("EngineDropdown").GetComponent<TMP_Dropdown>();
        engineDropdown.onValueChanged.AddListener(BrakeChangedUpdate);
        EngineSelected = (Engine)engineDropdown.value;
        
        // F
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = EngineMaterial[(int)EngineSelected];
    }

    void BrakeChangedUpdate(int value)
    {
        
        EngineSelected = (Engine)value;
        rend.sharedMaterial = EngineMaterial[value];
        //Debug.Log("Colour Changed: " + ColourSelected.ToString());
    }
}
