using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCharge
{
    //Fields
    float _currentCharge;
    float _currentMaxCharge;

    // Properties

    public float Charge
    { 
    get
        {
            return _currentCharge;
        }
     set
        {
            _currentCharge = value;
        }

    }


    public float MaxCharge
    {
        get
        {
            return _currentMaxCharge;
            }
        set
        {
            _currentMaxCharge = value;
        }

    }

    // constuctor

    public UnitCharge(float charge, float maxCharge)
    {
        _currentCharge = charge;
        _currentMaxCharge = maxCharge;
    }

    // Methods

    public void UseCharge(float chargeAmount) // when attacking with charge
    {
        if (_currentCharge > 0)
        {
            _currentCharge -= chargeAmount;
        }
    }

    public void FillCharge(float fillAmount) // when at a charge station
    {
        if (_currentCharge < _currentMaxCharge)
        {
            _currentCharge += fillAmount;
        }
        if (_currentCharge > _currentMaxCharge)
        {
            _currentCharge = _currentMaxCharge;
        }
    }


}
