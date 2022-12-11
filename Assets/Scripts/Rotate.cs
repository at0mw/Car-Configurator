using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update

    private Slider rotateSlider;

    public float rotMinValue;
    public float rotMaxValue;

    void Start()
    {
        //find sliders by name
        // initialise max and min
        // Add listener to the slider value when changed

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = rotMinValue;
        rotateSlider.maxValue = rotMaxValue;

        rotateSlider.onValueChanged.AddListener(RotateValueUpdate);



    }

    void RotateValueUpdate(float value)
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
    }
    // Control Y value with slider
    // Need min and max values
    

}
