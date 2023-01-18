using Enums;
using TMPro;
using UnityEngine;

namespace Manage_Car_Config
{
    public class InteriorChanger : MonoBehaviour
    {
        [SerializeField]private TMP_Dropdown interiorDropdown;

        public InteriorStyle styleSelected;
        [SerializeField]private Material[] interiorMaterial;
        private Renderer _rend;
        
        private void Start()
        {
            interiorDropdown.onValueChanged.AddListener(ColourChangedUpdate);
            styleSelected = (InteriorStyle)interiorDropdown.value;
        
            // F
            _rend = GetComponent<Renderer>();
            _rend.enabled = true;
            _rend.sharedMaterial = interiorMaterial[(int)styleSelected];
        }

        private void ColourChangedUpdate(int value)
        {        
            styleSelected = (InteriorStyle)value;
            _rend.sharedMaterial = interiorMaterial[value];
        }
    }
}
