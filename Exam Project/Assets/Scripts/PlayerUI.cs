using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Slider chargeSlider;

    [SerializeField] private Text objectiveText;

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
    }

    void DisplayObjectives()
    {
        string completeMsg;
        // if (_levelManager.objectivesComplete)
        //     completeMsg = "Area"
        //
        objectiveText.text = $"Objectives: \n \n" +
                             $"Turn on Generators: {_levelManager.generatorCount}/{_levelManager.generatorObjective} \n" +
                             $"Turn on Lamps: {_levelManager.lampCount}/{_levelManager.lampObjective} \n" +
                             $"Defeat Tokoloshes: {_levelManager.enemyCount}/{_levelManager.enemyObjective} \n" +
                             $"";
        
        
    }
}
