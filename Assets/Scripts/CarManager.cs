using System;
using Manage_Car_Config;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private static CarManager _instance;
    // Hold references to all parts and functions of the car
    // Be able to alter car configurations after json read
    // Be able to save car configurations to json
    #region Car Part References
    private GameObject _carBody;
    private ColourChanger _carBodyColour;
    private GameObject _carGrills;
    private EngineChanger _carEngineModel;
    private GameObject _carInterior;    
    private InteriorChanger _carInteriorStyle;
    
    private bool _isCarBodyColourNull;
    private bool _isCarInteriorStyleNull;
    private bool _isCarEngineModelNull;
    #endregion Car Part References

    private void Start()
    {
        _carBody = GameObject.Find("PP_Body");
        _carGrills = GameObject.Find("PP_Grills");
        _carInterior = GameObject.Find("PP_Interior");

        _carBodyColour = _carBody.GetComponent<ColourChanger>();        
        _carEngineModel = _carGrills.GetComponent<EngineChanger>();        
        _carInteriorStyle = _carInterior.GetComponent<InteriorChanger>();
        
        _isCarEngineModelNull = _carEngineModel == null;
        _isCarInteriorStyleNull = _carInteriorStyle == null;
        _isCarBodyColourNull = _carBodyColour == null;
    }

    public static CarManager GetInstance()
    {
        if (_instance != null)
            return _instance;
        
        _instance = FindObjectOfType<CarManager>();
        if (_instance != null)
            return _instance;

        var go = new GameObject("CarManager");
        _instance = go.AddComponent<CarManager>();
        return _instance;
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Enum CheckColour()
    {
        if (_isCarBodyColourNull)
            return null;
        
        return _carBodyColour.colourSelected;
    }

    public Enum CheckInteriorStyle()
    {
        if (_isCarInteriorStyleNull)
            return null;
        
        return _carInteriorStyle.styleSelected;
    }

    public Enum CheckEngine()
    {
        if (_isCarEngineModelNull)
            return null;
        
        return _carEngineModel.EngineSelected;
    }
}
