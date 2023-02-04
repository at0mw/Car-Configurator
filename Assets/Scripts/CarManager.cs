using System;
using Enums;
using Manage_Car_Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CarManager : MonoBehaviour, IObserver
{
    private static CarManager _instance;
    #region Car Part References
    [SerializeField]private CarConfiguration carConfiguration;
    [SerializeField]private TMP_Dropdown colourDropdown;
    [SerializeField] private TMP_Dropdown engineDropdown;
    [SerializeField] private TMP_Dropdown interiorStyleDropdown;
    [SerializeField] private Button saveButton;
    
    [SerializeField]private GameObject priceText;
    #endregion Car Part References

    [NonSerialized]public double CarBasePrice;

    [NonSerialized]public double CurrentColourPrice;
    [NonSerialized]public double CurrentEnginePrice;
    [NonSerialized]public double CurrentInteriorStylePrice;
    private PriceCalculator _priceCalculator;
    
    private void Start()
    {
        Debug.Log("Start Up");
        saveButton.onClick.AddListener(SaveData);
        ColourChanger.Instance.Attach(this);
        InteriorChanger.Instance.Attach(this);
        EngineChanger.Instance.Attach(this);
    }
    
    public void Notify(Message message)
    {
        Debug.Log("Here we are!!!!!!!!");
        switch (message.MessageType)
        {
            case MessageType.Colour:
                CurrentColourPrice = _priceCalculator.UpdateColour(message.Colour);
                break;
            case MessageType.Interior:
                CurrentEnginePrice = _priceCalculator.UpdateInterior(message.InteriorStyle);
                break;
            case MessageType.Engine:
                CurrentInteriorStylePrice = _priceCalculator.UpdateEngine(message.Engine);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
            
        _priceCalculator.UpdatePrice();
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
        Debug.Log("AWAKENING");
        _priceCalculator = priceText.GetComponent<PriceCalculator>();
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        Debug.Log("setting values");
        colourDropdown.value = (int)carConfiguration.colour;
        engineDropdown.value = (int)carConfiguration.engine;
        interiorStyleDropdown.value = (int)carConfiguration.interiorStyle;
        _priceCalculator.InitialisePrice(carConfiguration.carBasePrice);
        //CarPrice = carConfiguration.carPrice;
        //CurrentColourPrice = carConfiguration.colourPrice;
        //CurrentEnginePrice = carConfiguration.enginePrice;
        //CurrentInteriorStylePrice = carConfiguration.interiorStylePrice;
        CurrentColourPrice = _priceCalculator.UpdateColour(carConfiguration.colour);
        CurrentEnginePrice = _priceCalculator.UpdateEngine(carConfiguration.engine);
        CurrentInteriorStylePrice = _priceCalculator.UpdateInterior(carConfiguration.interiorStyle);
        CarBasePrice = carConfiguration.carBasePrice;
        _priceCalculator.UpdatePrice();
        // Load in car data scriptable object
    }

    private void SaveData()
    {
        Debug.Log("Saving......");
        carConfiguration.colour = (Colour)colourDropdown.value;
        carConfiguration.engine = (Engine)engineDropdown.value;
        carConfiguration.interiorStyle = (InteriorStyle)interiorStyleDropdown.value;
        carConfiguration.carBasePrice = CarBasePrice;
        
        carConfiguration.colourPrice = CurrentColourPrice;
        carConfiguration.enginePrice = CurrentEnginePrice;
        carConfiguration.interiorStylePrice = CurrentInteriorStylePrice;
        carConfiguration.carPrice = _priceCalculator.CurrentPrice;
    }

    public void UpdatePrice()
    {
        _priceCalculator.UpdatePrice();
    }
}
