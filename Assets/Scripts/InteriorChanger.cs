using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteriorChanger : MonoBehaviour
{
    public TMP_Dropdown interiorDropdown;
    public enum InteriorStyle
    {
        Normal,
        CreamLeather,
        InvisiPaint
    }
    public InteriorStyle StyleSelected;
    public Material[] InteriorMaterial;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        interiorDropdown = GameObject.Find("InteriorDropdown").GetComponent<TMP_Dropdown>();
        interiorDropdown.onValueChanged.AddListener(ColourChangedUpdate);
        StyleSelected = (InteriorStyle)interiorDropdown.value;
        
        // F
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = InteriorMaterial[(int)StyleSelected];
    }

    void ColourChangedUpdate(int value)
    {        
        StyleSelected = (InteriorStyle)value;
        rend.sharedMaterial = InteriorMaterial[value];
    }
}
