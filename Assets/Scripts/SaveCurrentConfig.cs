using UnityEngine;
using UnityEngine.Serialization;

public class SaveCurrentConfig : MonoBehaviour
{
    [FormerlySerializedAs("_carConfig")] [SerializeField] private CarConfig carConfig = new CarConfig();

    public void SaveIntoJson()
    {
        var config = JsonUtility.ToJson(this.carConfig);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/CarConfig.json", config);
    }
}

[System.Serializable]
public struct CarConfig
{
    public string colour;
    public string interiorDesign;
    public string engine;
    public int price;
}