using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public List<GameObject> passedThrough;
    public List<string> tags;
    
    [Header("Arc data")]
    public GameObject ArcObj;
    public float arcDistance;
    public float arcDuration;
    public float arcTravelSpeed;
    public float arcDamage;
    public float stunTime;

    public float electricDamage;
    [SerializeField] private ElectricArc rootElectricArc;
    

    public void StartElectricArc(GameObject startObj, float damage, float stunTime = 0)
    {
        //objectsElectricityPassedThrough.Add(startTransform);
        arcDamage = damage;
        rootElectricArc = new ElectricArc(this, startObj);
    }

    public GameObject CreateBolt()
    {
        GameObject obj = Instantiate(ArcObj);
        //Destroy(obj,arcDuration);
        return obj;
    }

    public void ArcFound(ElectricArc currentArc, float travelDistance, GameObject endObj)
    {
        var coroutine = ArcTraveling(currentArc,travelDistance,endObj);
        StartCoroutine(coroutine);
    }
    
    IEnumerator ArcTraveling(ElectricArc currentArc, float travelDistance, GameObject endObj)
    {
        Debug.Log("coroutine start");
        float timer = 0;
        float timerInc = 0.05f;
        while (timer < (travelDistance /arcTravelSpeed))
        {
            timer += timerInc;
            Vector3 endPos = (currentArc.startObj.transform.position - endObj.transform.position).normalized *
                             (travelDistance - arcTravelSpeed * timer); 
            currentArc.arcObj.GetComponent<LightningBoltScript>().EndPosition = endPos;

            
            yield return new WaitForSeconds(timerInc);
        }
        
        currentArc.arcObj.GetComponent<LightningBoltScript>().EndPosition = Vector3.zero;
        currentArc.nexArc = new ElectricArc(this,endObj);
        Destroy(currentArc.arcObj,arcDuration);
        Debug.Log("coroutine end");
    }

    public void DeleteElectricity()
    {
        Destroy(gameObject,arcDuration);
    }
}
