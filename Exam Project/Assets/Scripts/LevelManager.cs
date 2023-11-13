using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    
    [Header("Objectives")]
    public int enemyObjective;
    public int lampObjective;
    public int generatorObjective;
    public int npcObjective;
    public int noteObjective;

    [Header("Counts")] 
    public int enemyCount;
    public int lampCount;
    public int generatorCount;
    public int npcCount;
    public int noteCount;


    [Header("Can complete level")] 
    public bool objectivesComplete;

    [Header("Respawn Pos")] 
    public Vector3 respawnPos;

    [Header("Goals")] 
    public List<Transform> generators;
    public List<Transform> npcs;
    public List<Transform> notes;

    public Transform endPoint;

    private void Start()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        respawnPos = _playerInfo.transform.position;
    }

    public void KillEnemy()
    {
        enemyCount++;
        CheckObjective();
    }

    public void LightLamp()
    {
        lampCount++;
        CheckObjective();
    }

    public void PowerGenerator(Transform generator)
    {
        generatorCount++;
        generators.Remove(generator);
        CheckObjective();
    }
    
    public void FindNote(Transform note)
    {
        noteCount++;
        generators.Remove(note);
        CheckObjective();
    }
    public void SpeakWithNPC(Transform npc)
    {
        npcCount++;
        generators.Remove(npc);
        CheckObjective();
    }
    
    public bool CheckObjective()
    {
        objectivesComplete = (enemyCount >= enemyObjective && lampCount >= lampObjective &&
                              generatorCount >= generatorObjective &&
                              noteCount >= noteObjective &&
                              npcCount >= npcObjective);

        return objectivesComplete;
    }
    
    
    
    public void PlayerDeath()
    {
        _playerInfo.Respawn(respawnPos);
    }

    public void Complete()
    {
        if (objectivesComplete)
        {
            Debug.Log("level complete");
        }
        else
        {
            Debug.Log("Not complete");
        }
    }
    
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitToMainMenu()
    {
        // test
        Debug.Log("Quit to main menu");
        RestartLevel();
        
        
        //SceneManager.LoadScene("");
    }
}
