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
}
