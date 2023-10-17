using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class SpawnElectricity : MonoBehaviour
{
    [SerializeField] private GameObject electricityObj;
    
    public void HitWithElectricity(GameObject startArc)
    {
        GameObject obj = Instantiate(electricityObj);
        
        obj.GetComponent<Electricity>().StartElectricArc(startArc.transform);
    }
}
