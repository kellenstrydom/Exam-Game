using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public List<Transform> objectsElectricityPassedThrough;
    public GameObject ArcObj;
    public float arcDistance;
    public float arcDuration;
    public float arcTravelSpeed;

    [SerializeField] private ElectricArc rootElectricArc;


    public Transform testStart;

    private void Start()
    {
        //StartElectricArc(testStart);
    }

    public void StartElectricArc(Transform startTransform)
    {
        Debug.Log("get root");
        //objectsElectricityPassedThrough.Add(startTransform);
        rootElectricArc = new ElectricArc(this, startTransform);
    }

    public bool IsObjectPassedThrough(Transform checkTransform)
    {
        return objectsElectricityPassedThrough.Contains(checkTransform);
    }

    public GameObject CreateBolt()
    {
        GameObject obj = Instantiate(ArcObj);
        //Destroy(obj,arcDuration);
        return obj;
    }

    public void ArcFound(ElectricArc currentArc, float travelDistance, Transform endTransform)
    {
        var coroutine = ArcTraveling(currentArc,travelDistance,endTransform);
        StartCoroutine(coroutine);
    }
    
    IEnumerator ArcTraveling(ElectricArc currentArc, float travelDistance, Transform endTransform)
    {
        Debug.Log("coroutine start");
        float timer = 0;
        while (timer < (travelDistance /arcTravelSpeed))
        {
            timer += 0.1f;
            yield return new WaitForSeconds(.1f);
        }
        
        currentArc.nexArc = new ElectricArc(this,endTransform);
        Destroy(currentArc.arcObj,arcDuration);
        Debug.Log("coroutine end");
    }

    public void DeleteElectricity()
    {
        Destroy(gameObject,arcDuration);
    }
}
