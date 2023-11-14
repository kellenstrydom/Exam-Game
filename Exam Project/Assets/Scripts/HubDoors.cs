using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HubDoors : MonoBehaviour
{
    public TMP_Text DoorText;

    public int indexNum;
    
    // Update is called once per frame
    void Start()
    {
        DoorText.text = EskomHub.DoorsOpen[indexNum]
            ? $"{EskomHub.sceneNameInorder[indexNum]} \n open"
            : $"{EskomHub.sceneNameInorder[indexNum]} \n locked";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!EskomHub.DoorsOpen[indexNum]) return;
        
        Debug.Log("Enter door");
        //EskomHub.CompleteScene(indexNum);
        //string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(EskomHub.sceneNameInorder[indexNum]);
    }
}
