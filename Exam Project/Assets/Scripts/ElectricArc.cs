using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ElectricArc : MonoBehaviour
{
    public ElectricArc nexArc;
    public float arcDistance;
    private Transform startTransform;
    public Transform endTransform;

    public float travelDistance;
    private LightningBoltScript boltScript;
    public GameObject arcObj;

    private Electricity _electricity;

    public ElectricArc(Electricity _electricity, Transform startTransform)
    {
        this._electricity = _electricity;
        this.startTransform = startTransform;
        arcDistance = this._electricity.arcDistance;
        this._electricity.objectsElectricityPassedThrough.Add(this.startTransform);
        Debug.Log("Arc");
        FindNextArc();
    }

    void FindNextArc()
    {
        Transform closest = null;
        Collider[] hitColliders = Physics.OverlapSphere(startTransform.position, arcDistance);
        Debug.Log(hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            if (!_electricity.IsObjectPassedThrough(hitCollider.transform))
            {
                if (closest == null) 
                    closest = hitCollider.transform;
                else
                {
                    if (Vector3.Distance(hitCollider.transform.position, startTransform.position) <
                        Vector3.Distance(closest.position, startTransform.position))
                    {
                        closest = hitCollider.transform;
                    }
                }
            }
        }
        
        
        
        if (closest)
        {
            Debug.Log($"{closest.name} is the closest");
            endTransform = closest;
            arcObj = _electricity.CreateBolt();
            arcObj.GetComponent<LightningBoltScript>().StartObject = startTransform.gameObject;
            arcObj.GetComponent<LightningBoltScript>().EndObject = endTransform.gameObject;

            travelDistance = Vector3.Distance(startTransform.position, endTransform.position);
            _electricity.ArcFound(this,travelDistance,endTransform);
        }
        else
        {
            Debug.Log("Arc Finished");
        }
    }

    IEnumerator ArcTraveling()
    {
        Debug.Log("coroutine start");
        float timer = 0;
        while (timer < (travelDistance /_electricity.arcTravelSpeed))
        {
            timer += 0.1f;
            yield return new WaitForSeconds(.1f);
        }
        
        nexArc = new ElectricArc(_electricity,endTransform);
        Debug.Log("coroutine end");
    }
    
}
