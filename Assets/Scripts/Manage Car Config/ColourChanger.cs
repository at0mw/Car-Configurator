using System.Collections.Generic;
using Enums;
using TMPro;
using UnityEngine;

namespace Manage_Car_Config
{
    public class ColourChanger : MonoBehaviour, ISubject
    {
        private static ColourChanger _instance;

        public static ColourChanger Instance
        {
            get { return _instance ?? (_instance = GameObject.FindObjectOfType<ColourChanger>()); }
        }
        [SerializeField]private TMP_Dropdown colourDropdown;


        private readonly List<IObserver> _observers = new List<IObserver>();
        public Colour colourSelected;
        [SerializeField]private Material[] bodyMaterial;
        private Renderer _rend;
        // Start is called before the first frame update
        void Start()
        {
            // TODO Serialise field
            //colourDropdown = GameObject.Find("ColourDropdown").GetComponent<TMP_Dropdown>();
            colourDropdown.onValueChanged.AddListener(ColourChangedUpdate);
            colourSelected = (Colour)colourDropdown.value;
        
            // TODO Notify on start of current colour - START SCREEN?
            //Notify();
            // F
            _rend = GetComponent<Renderer>();
            _rend.enabled = true;
            _rend.sharedMaterial = bodyMaterial[(int)colourSelected];
        }

        private void ColourChangedUpdate(int value)
        {
            colourSelected = (Colour)value;
            _rend.sharedMaterial = bodyMaterial[value];
            var message = new Message
            {
                Colour = (Colour)value
            };
            Notify(message);
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Message message)
        {
            if (_observers.Count == 0)
                return;

            foreach (var observer in _observers)
            {
                observer.Notify(message);
            }
        }
    }
}
