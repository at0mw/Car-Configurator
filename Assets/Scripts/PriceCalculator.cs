using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceCalculator : MonoBehaviour
{
    #region Car Part References
    GameObject carBody;
    ColourChanger colourOfCarBody;
    GameObject carGrills;
    EngineChanger styleOfCarGrills;
    GameObject carInterior;    
    InteriorChanger styleOfCarInterior;
    private TMP_Text priceText;
    #endregion Car Part References

    #region HardCoded Prices
    private const decimal CarBasePrice = 100000;
    // Colours
    private const decimal LimeGreenPrice = 28000;
    
    private const decimal HotRedPrice = 22000;
    
    private const decimal SeaBluePrice = 12000;
    
    private const decimal SoftPinkPrice = 15000;
    
    private const decimal BoneWhitePrice = 8000;
    
    private const decimal VoidBlackPrice = 8000;
    //Styles
    private const decimal NormalPrice = 1000;
    
    private const decimal CreamLeatherPrice = 20000;
    
    private const decimal InvisPrice = -9000;
    // Models
    private const decimal StreetPrice = 12000;
    
    private const decimal RacingPrice = 39000;
    // Start is called before the first frame update
    #endregion HardCoded Prices

    void Start()
    {
        carBody = GameObject.Find("PP_Body");
        carGrills = GameObject.Find("PP_Grills");
        carInterior = GameObject.Find("PP_Interior");

        colourOfCarBody = carBody.GetComponent<ColourChanger>();        
        styleOfCarGrills = carGrills.GetComponent<EngineChanger>();        
        styleOfCarInterior = carInterior.GetComponent<InteriorChanger>();


        priceText = GameObject.Find("Pricing (1)").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {    
        Debug.Log("Pricing = " + CurrentPrice());
        priceText.text = "£" + CurrentPrice();
    }

    decimal CurrentPrice()
    {
        return CarBasePrice + FindEngineValue() + FindColourValue() + FindStyleValue();
    }
    decimal FindColourValue()
    {
        switch(colourOfCarBody.ColourSelected)
        {
            case ColourChanger.Colour.LimeGreen: { return LimeGreenPrice; }
            case ColourChanger.Colour.HotRed: { return HotRedPrice; }
            case ColourChanger.Colour.SeaBlue: { return SeaBluePrice; }
            case ColourChanger.Colour.SoftPink: { return SoftPinkPrice; }
            case ColourChanger.Colour.BoneWhite: { return BoneWhitePrice; }
            case ColourChanger.Colour.VoidBlack: { return VoidBlackPrice; }
            default: { return 0; }
        }        
    }

    decimal FindStyleValue()
    {
        switch(styleOfCarInterior.StyleSelected)
        {
            case InteriorChanger.InteriorStyle.Normal: { return NormalPrice; }
            case InteriorChanger.InteriorStyle.CreamLeather: { return CreamLeatherPrice; }
            case InteriorChanger.InteriorStyle.InvisiPaint: { return InvisPrice; }
            default: { return 0; }
        }        
    }

        decimal FindEngineValue()
    {
        switch(styleOfCarGrills.EngineSelected)
        {
            case EngineChanger.Engine.Street: { return StreetPrice; }
            case EngineChanger.Engine.Racing: { return RacingPrice; }
            default: { return 0; }
        }        
    }
    
}
