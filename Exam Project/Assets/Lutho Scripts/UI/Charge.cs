using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{
    Slider _chargeSlider;

    private void Start()
    {
        _chargeSlider = GetComponent<Slider>();
    }

    public void SetMaxCharge( int maxCharge)
    {
        _chargeSlider.maxValue = maxCharge;
        _chargeSlider.value = maxCharge;
    }

    public void SetCharge(int Charge)
    {
        _chargeSlider.value = Charge;
    }
}
