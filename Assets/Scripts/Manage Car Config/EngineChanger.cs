using System.Collections.Generic;
using TMPro;
using Enums;
using UnityEngine;

namespace Manage_Car_Config
{
    public class EngineChanger : MonoBehaviour, ISubject
    {
        [SerializeField]private TMP_Dropdown engineDropdown;
        public Engine EngineSelected;
        [SerializeField]private Material[] engineMaterial;
        Renderer rend;
        
        private static EngineChanger _instance;

        public static EngineChanger Instance => _instance ? _instance : (_instance = GameObject.FindObjectOfType<EngineChanger>());
        
        private readonly List<IObserver> _observers = new();
        // Start is called before the first frame update
        private void Start()
        {
            engineDropdown.onValueChanged.AddListener(BrakeChangedUpdate);
            EngineSelected = (Engine)engineDropdown.value;

            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = engineMaterial[(int)EngineSelected];
        }
        
        private void BrakeChangedUpdate(int value)
        {
            EngineSelected = (Engine)value;
            rend.sharedMaterial = engineMaterial[value];
            var message = new Message
            {
                MessageType = MessageType.Engine,
                Engine = (Engine)value
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
