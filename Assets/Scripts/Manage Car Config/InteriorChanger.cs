using System;
using System.Collections.Generic;
using Enums;
using TMPro;
using UnityEngine;

namespace Manage_Car_Config
{
    public class InteriorChanger : MonoBehaviour, ISubject
    {
        [SerializeField]private TMP_Dropdown interiorDropdown;

        private readonly List<IObserver> _observers = new();
        public InteriorStyle styleSelected;
        [SerializeField]private Material[] interiorMaterial;
        private Renderer _rend;
        
        private static InteriorChanger _instance;

        public static InteriorChanger Instance => _instance ? _instance : (_instance = GameObject.FindObjectOfType<InteriorChanger>());
        
        private void Start()
        {
            interiorDropdown.onValueChanged.AddListener(InteriorStyleChangedUpdate);
            styleSelected = (InteriorStyle)interiorDropdown.value;

            _rend = GetComponent<Renderer>();
            _rend.enabled = true;
            _rend.sharedMaterial = interiorMaterial[(int)styleSelected];
        }

        private void InteriorStyleChangedUpdate(int value)
        {
            Debug.Log("Changing Interior Style");
            styleSelected = (InteriorStyle)value;
            _rend.sharedMaterial = interiorMaterial[value];
            var message = new Message
            {
                MessageType = MessageType.Interior,
                InteriorStyle = (InteriorStyle)value
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

            Debug.Log("Hmm");
            foreach (var observer in _observers)
            {
                observer.Notify(message);
            }
        }
    }
}
