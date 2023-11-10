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
        
    }

    public void LightLamp()
    {
        
    }

    public void PowerGenerator()
    {
        
    }
    
    public void CheckObjective()
    {
        objectivesComplete = (enemyCount >= enemyObjective && lampCount >= lampObjective &&
                              generatorCount >= generatorObjective);
    }
    
    public void PlayerDeath()
    {
        
    }

    public void Complete()
    {
        
    }
}
