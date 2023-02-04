using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Car Config Save", menuName = "Scriptable Objects/Saves")]
public class CarConfiguration : ScriptableObject
{
    public Colour colour;
    public double colourPrice;
    public Engine engine;
    public double enginePrice;
    public InteriorStyle interiorStyle;
    public double interiorStylePrice;
    public double carBasePrice;
    public double carPrice;

    private double _colourPrice;
}
