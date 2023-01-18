using UnityEngine;

public class HeadLightLedToggle : MonoBehaviour
{
    //[SerializeField]private GameObject headlightLed;
    [SerializeField]private Renderer _headlightRenderer;
    //private Button _lightingButton;
    
    // Start is called before the first frame update
    private void Start()
    {
        var lightingButton = GetComponent<UnityEngine.UI.Button>();
        lightingButton.onClick.AddListener(ToggleLed);
    }

    private void ToggleLed()
    {
        Debug.Log("Headlights Script Running");
        var isEnabled = _headlightRenderer.enabled;

        _headlightRenderer.enabled = !isEnabled;
    }
}
