using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

    [Header("Objective List")]
    public RectTransform objectiveTransform;
    public float showRectPosY;
    public float hideRectPosY;
    public float slideTime;
    public bool isObjectiveOpen;

    private PlayerInfo _playerInfo;
    private LevelManager _levelManager;
    
    [Header("Objective List")]
    [SerializeField]
    public bool isPaused;
    public GameObject pauseMenu;
    public RectTransform compass;

    private void Start()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        _levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        isPaused = true;
        Pause();

        isObjectiveOpen = true;
        objectiveTab();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (isPaused) return;
        
        healthSlider.value = (int)(_playerInfo.healthPoints / PlayerInfo.MaxHealthPoints * 100);
        chargeSlider.value = (int)(_playerInfo.charge / PlayerInfo.MaxCharge * 100);
        
        DisplayObjectives();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            objectiveTab();
        }
        
        PointCompass();
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
                             $"Generators: {_levelManager.generatorCount}/{_levelManager.generatorObjective} \n \n" +
                             $"Lamps: {_levelManager.lampCount}/{_levelManager.lampObjective} \n \n" +
                             $"Tokoloshes: {_levelManager.enemyCount}/{_levelManager.enemyObjective} \n \n" +
                             $"Notes: {_levelManager.noteCount}/{_levelManager.noteObjective} \n \n" +
                             $"NPCs: {_levelManager.npcCount}/{_levelManager.npcObjective}";
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
            t += Time.deltaTime * 1/slideTime;
            if (t > 1) t = 1;
            float newY = Mathf.Lerp(yStart, yEnd, t);
            objectiveTransform.anchoredPosition = new Vector2(objectiveTransformPos.x, newY);
            yield return null;
        }
    }

    void PointCompass()
    {
        compass.rotation = _playerInfo.closestGen.rotation;
    }

    public void Pause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        isPaused = !isPaused;
    }

    public void Restart()
    {
        _levelManager.RestartLevel();
    }

    public void Quit()
    {
        _levelManager.QuitToMainMenu();
    }
}
