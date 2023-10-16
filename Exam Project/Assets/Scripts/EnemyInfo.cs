using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public bool isHoldingElectricity = false;
    
    public void Electrocuted(float shockDuration)
    {
        isHoldingElectricity = true;
        Invoke(nameof(ResetElectricity),shockDuration);
    }

    public void ResetElectricity()
    {
        isHoldingElectricity = false;
    }
}
