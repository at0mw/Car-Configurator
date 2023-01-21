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
    public class PriceCalculator : MonoBehaviour, IObserver
    {
        private CarManager _carManager;

        [SerializeField] private TMP_Text priceText;
        [SerializeField] private List<ColourPrice> colourPrices;
        [SerializeField] private List<InteriorStylePrice> interiorStylePrices;
        [SerializeField] private List<EnginePrice> enginePrices;
        [SerializeField]private double carBasePrice = 100000;

        void Start()
        {
            //TODO Attach Interior and Engine Instances
            ColourChanger.Instance.Attach(this);
            InteriorChanger.Instance.Attach(this);
            EngineChanger.Instance.Attach(this);
            _carManager = CarManager.GetInstance();
        }
        
        public void Notify(Message message)
        {
            var numericalPrice = carBasePrice + FindColourPrice(message.Colour) 
                                              + FindEnginePrice(message.Engine) + FindInteriorStylePrice(message.InteriorStyle);
            priceText.text = "£" + numericalPrice; //TODO + FindEnginePrice etc
        }

        private double FindColourPrice(Colour colour)
        {
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