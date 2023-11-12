using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
     
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Slider chargeSlider;

    [SerializeField] private TMP_Text objectiveText;

    public float showRectPosY;
    public float hideRectPosY;
    public float moveSpeed;
    public bool isObjectiveOpen;

    public RectTransform objectiveTransform;

    private PlayerInfo _playerInfo;
    private LevelManager _levelManager;

    private void Start()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        _levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
    }

    void Update()
    {
        healthSlider.value = (int)(_playerInfo.HealthPoints / _playerInfo.MaxHealthPoints * 100);
        chargeSlider.value = (int)(_playerInfo.charge / _playerInfo.maxCharge * 100);
        
        DisplayObjectives();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            objectiveTab();
        }
    }

    void DisplayObjectives()
    {
        string completeMsg;
        if (_levelManager.objectivesComplete)
            completeMsg = "Complete";
        else
        {
            completeMsg = "Incomplete";
        }
        
        
        objectiveText.text = $"Objectives: {completeMsg}\n \n" +
                             $"Turn on Generators: {_levelManager.generatorCount}/{_levelManager.generatorObjective} \n \n" +
                             $"Turn on Lamps: {_levelManager.lampCount}/{_levelManager.lampObjective} \n \n" +
                             $"Defeat Tokoloshes: {_levelManager.enemyCount}/{_levelManager.enemyObjective}";
    }


    void objectiveTab()
    {
        if (isObjectiveOpen)
        {
            StartCoroutine(SlideObjectiveTab(hideRectPosY));
        }
        else
        {
            StartCoroutine(SlideObjectiveTab(showRectPosY));
        }

        isObjectiveOpen = !isObjectiveOpen;
    }

    IEnumerator SlideObjectiveTab(float yEnd)
    {
        var objectiveTransformPos = objectiveTransform.anchoredPosition;
        float yStart = objectiveTransformPos.y;

        float t = 0;

        while (t < 1)
        {
            Debug.Log(t);
            t += Time.deltaTime;
            if (t > 1) t = 1;
            float newY = Mathf.Lerp(yStart, yEnd, t);
            objectiveTransform.anchoredPosition = new Vector2(objectiveTransformPos.x, newY);
            yield return null;
        }
        
    }
    
}
