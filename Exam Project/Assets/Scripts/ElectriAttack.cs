using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectriAttack : MonoBehaviour
{
    [SerializeField] private GameObject electricityObj;
    private bool hasArced;
    public float arcDamage;

    private void Update()
    {
        if (hasArced) hasArced = !gameObject.activeInHierarchy;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!electricityObj.GetComponent<Electricity>().tags.Contains(other.tag) && other.gameObject != gameObject) return;
        
        Debug.Log(name + " ZAPP");
        hasArced = true;
        HitWithElectricity(other.gameObject);
    }

    public void HitWithElectricity(GameObject startArc)
    {
        Debug.Log("Make ZAPPP");
        GameObject obj = Instantiate(electricityObj);
        
        obj.GetComponent<Electricity>().StartElectricArc(startArc, arcDamage);
    }
}
