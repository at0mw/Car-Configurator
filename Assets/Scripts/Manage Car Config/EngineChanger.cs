using TMPro;
using Enums;
using UnityEngine;

namespace Manage_Car_Config
{
    public class EngineChanger : MonoBehaviour
    {
        [SerializeField]private TMP_Dropdown engineDropdown;
        public Engine EngineSelected;
        [SerializeField]private Material[] engineMaterial;
        Renderer rend;
        // Start is called before the first frame update
        private void Start()
        {
            engineDropdown.onValueChanged.AddListener(BrakeChangedUpdate);
            EngineSelected = (Engine)engineDropdown.value;
        
            // F
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = engineMaterial[(int)EngineSelected];
        }

        private void BrakeChangedUpdate(int value)
        {
        
            EngineSelected = (Engine)value;
            rend.sharedMaterial = engineMaterial[value];
            //Debug.Log("Colour Changed: " + ColourSelected.ToString());
        }
    }
}
