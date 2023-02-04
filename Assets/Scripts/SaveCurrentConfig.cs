using Enums;
using Manage_Car_Config;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveCurrentConfig : MonoBehaviour
{
    public CarConfiguration carConfig;
    public void SaveToScriptableObject()
    {
        carConfig.colour = ColourChanger.Instance.colourSelected;
        carConfig.engine = EngineChanger.Instance.EngineSelected;
        carConfig.interiorStyle = InteriorChanger.Instance.styleSelected;
    }
}