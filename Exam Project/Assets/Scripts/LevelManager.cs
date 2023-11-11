using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Objectives")]
    public int enemyObjective;
    public int lampObjective;
    public int generatorObjective;

    [Header("Counts")] 
    public int enemyCount;
    public int lampCount;
    public int generatorCount;

    [Header("Can complete level")] 
    public bool objectivesComplete;

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

    public void PowerGenerator()
    {
        generatorCount++;
        CheckObjective();
    }
    
    public bool CheckObjective()
    {
        objectivesComplete = (enemyCount >= enemyObjective && lampCount >= lampObjective &&
                              generatorCount >= generatorObjective);

        return objectivesComplete;
    }
    
    public void PlayerDeath()
    {
        
    }

    public void Complete()
    {
        
    }
}
