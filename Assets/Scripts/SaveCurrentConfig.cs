using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCurrentConfig : MonoBehaviour
{
    [SerializeField] private CarConfig _carConfig = new CarConfig();

    public void SaveIntoJson(){
        string carConfig = JsonUtility.ToJson(_carConfig);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/CarConfig.json", carConfig);
    }
}

[System.Serializable]
public class CarConfig{
    public string colour;
    public string interiorDesign;
    public string engine;
    public int price;
}