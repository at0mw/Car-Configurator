using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColourChanger : MonoBehaviour
{
    public TMP_Dropdown colourDropdown;
    public enum Colour
    {
        LimeGreen,
        HotRed,
        SeaBlue,
        SoftPink,
        BoneWhite,
        VoidBlack
    }
    public Colour ColourSelected;
    public Material[] BodyMaterial;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        colourDropdown = GameObject.Find("ColourDropdown").GetComponent<TMP_Dropdown>();
        colourDropdown.onValueChanged.AddListener(ColourChangedUpdate);
        ColourSelected = (Colour)colourDropdown.value;
        
        // F
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = BodyMaterial[(int)ColourSelected];
    }

    void ColourChangedUpdate(int value)
    {
        
        ColourSelected = (Colour)value;
        rend.sharedMaterial = BodyMaterial[value];
        //Debug.Log("Colour Changed: " + ColourSelected.ToString());
    }
}
