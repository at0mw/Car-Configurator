using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Config")]
public class CarConfiguration : ScriptableObject
{
    public Colour colour;
    public Engine engine;
    public InteriorStyle interiorStyle;
}
