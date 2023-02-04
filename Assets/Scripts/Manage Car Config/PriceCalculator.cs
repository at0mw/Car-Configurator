using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using static Manage_Car_Config.ColourChanger;

namespace Manage_Car_Config
{
    public class PriceCalculator : MonoBehaviour
    {
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private List<ColourPrice> colourPrices;
        [SerializeField] private List<InteriorStylePrice> interiorStylePrices;
        [SerializeField] private List<EnginePrice> enginePrices;
        //[SerializeField] private double carBasePrice = 100000;

        private double _currentColourPrice;
        private double _currentEnginePrice;
        private double _currentStylePrice;

        private CarManager Manager => CarManager.GetInstance();

        public double CurrentPrice { get; private set; }

        public void InitialisePrice(double currentPrice)
        {
            CurrentPrice = currentPrice;
        }

        // void Start()
        // {
        //     //TODO Attach Interior and Engine Instances
        //     ColourChanger.Instance.Attach(this);
        //     InteriorChanger.Instance.Attach(this);
        //     EngineChanger.Instance.Attach(this);
        // }
        //
        // public void Notify(Message message)
        // {
        //     switch (message.MessageType)
        //     {
        //         case MessageType.Colour:
        //             UpdateColour(message.Colour);
        //             break;
        //         case MessageType.Interior:
        //             UpdateInterior(message.InteriorStyle);
        //             break;
        //         case MessageType.Engine:
        //             UpdateEngine(message.Engine);
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        //     
        //     UpdatePrice();
        // }
        
        public double UpdateColour(Colour newColour)
        {
            Debug.Log($"New Colour: {newColour}");
            return FindColourPrice(newColour);
        }
        
        public double UpdateEngine(Engine newEngine)
        {
            return FindEnginePrice(newEngine);
        }

        public double UpdateInterior(InteriorStyle newStyle)
        {
            return FindInteriorStylePrice(newStyle);
        }
        
        public void UpdatePrice()
        {
            Debug.Log($"Price {Manager.CarBasePrice} Colour {Manager.CurrentColourPrice} Engine {Manager.CurrentEnginePrice} Style {Manager.CurrentInteriorStylePrice}");
            CurrentPrice = Manager.CarBasePrice + Manager.CurrentColourPrice 
                                            + Manager.CurrentEnginePrice + Manager.CurrentInteriorStylePrice;
            priceText.text = "£" + CurrentPrice;
        }
        
        private double FindColourPrice(Colour colour)
        {
            Debug.Log($"Here we are with colour {colour}");
            foreach (var colourPrice in colourPrices.Where(colourPrice => colourPrice.colour == colour))
            {
                return colourPrice.price;
            }
            return double.MinValue;
        }

        private double FindInteriorStylePrice(InteriorStyle interiorStyle)
        {
            foreach (var interiorStylePrice in interiorStylePrices.Where(interiorStylePrice => interiorStylePrice.style == interiorStyle))
            {
                return interiorStylePrice.price;
            }
            return double.MinValue;
        }
        
        private double FindEnginePrice(Engine engine)
        {
            foreach (var enginePrice in enginePrices.Where(enginePrice => enginePrice.engine == engine))
            {
                return enginePrice.price;
            }
            return double.MinValue;
        }
    }
    
    [Serializable]
    public struct ColourPrice
    {
        public double price;
        public Colour colour;
    }

    [Serializable]
    public struct InteriorStylePrice
    {
        public double price;
        public InteriorStyle style;
    }

    [Serializable]
    public struct EnginePrice
    {
        public double price;
        public Engine engine;
    }
}