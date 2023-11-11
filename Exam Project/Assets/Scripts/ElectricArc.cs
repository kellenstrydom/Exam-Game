using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DigitalRuby.LightningBolt;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ElectricArc : MonoBehaviour
{
    public ElectricArc nexArc;
    public float arcDistance;
    public GameObject startObj;
    public GameObject endObj;

    public float travelDistance;
    private LightningBoltScript boltScript;
    public GameObject arcObj;

    private Electricity _electricity;

    public ElectricArc(Electricity _electricity, GameObject startObj)
    {
        this._electricity = _electricity;
        this.startObj = startObj;
        arcDistance = this._electricity.arcDistance;
        this._electricity.passedThrough.Add(this.startObj);
        Debug.Log("Arc");
        startObj.GetComponent<EnemyData>()?.TakeDamage(_electricity.arcDamage);
        FindNextArc();
    }

    void FindNextArc()
    {
        GameObject closest = null;
        Collider[] hitColliders = Physics.OverlapSphere(startObj.transform.position, arcDistance);
        //Debug.Log(hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                //if (!_electricity.passedThrough.Contains(hitCollider.gameObject) && !_electricity.tags.Contains(hitCollider.tag))
                if (!_electricity.passedThrough.Contains(hitCollider.gameObject))
                {
                    if (closest == null) 
                        closest = hitCollider.gameObject;
                    else
                    {
                        if (Vector3.Distance(hitCollider.transform.position, startObj.transform.position) <
                            Vector3.Distance(closest.transform.position, startObj.transform.position))
                        {
                            closest = hitCollider.gameObject;
                        }
                    }
                }
            }
        }
        
        
        
        if (closest)
        {
            Debug.Log($"{closest.name} is the closest");
            endObj = closest;
            arcObj = _electricity.CreateBolt();
            arcObj.GetComponent<LightningBoltScript>().StartObject = startObj.gameObject;
            arcObj.GetComponent<LightningBoltScript>().EndObject = endObj.gameObject;
            travelDistance = Vector3.Distance(startObj.transform.position, endObj.transform.position);
            _electricity.ArcFound(this,travelDistance,endObj);
        }
        else
        {
            Debug.Log("Arc Finished");
            _electricity.DeleteElectricity();
        }
    }
    
    
}
