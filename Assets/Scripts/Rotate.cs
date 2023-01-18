using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    [SerializeField]private Slider rotateSlider;

    private void Start()
    {
        rotateSlider.onValueChanged.AddListener(RotateValueUpdate);
    }

    private void RotateValueUpdate(float value)
    {
        Debug.Log("Here");
        var transform1 = transform;
        var rotation = transform1.rotation;
        
        transform1.localEulerAngles = new Vector3(rotation.x, value, rotation.z);
    }
}
