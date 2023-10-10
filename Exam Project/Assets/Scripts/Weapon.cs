using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerControls _playerControls;
    
    public List<AttackClass> lightAttacks;
    public List<AttackClass> heavyAttacks;
    

    [SerializeField]
    int lightComboCount;
    [SerializeField]
    int heavyComboCount;
    
    [SerializeField] private float comboTimer;
    [SerializeField] private float comboGraceTime;
    
    
    private void Update()
    {
        if (lightComboCount != 0)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer > comboGraceTime)
                lightComboCount = 0;
        }
    }


    public void LightAttack()
    {
        StartCoroutine(Attack(lightAttacks[lightComboCount]));
        lightComboCount = (lightComboCount +1) % lightAttacks.Count;
    }

    public void HeavyAttack()
    {
        StartCoroutine(Attack(heavyAttacks[heavyComboCount]));
        heavyComboCount = (heavyComboCount +1) % heavyAttacks.Count;

    }
    
    IEnumerator Attack(AttackClass currentAttack)
    {
        _playerControls.currentState = PlayerControls.ActionState.attacking;
        yield return new WaitForSeconds(currentAttack.startDelay);
        currentAttack.Attack();
        yield return new WaitForSeconds(currentAttack.hitBoxActiveDuration);
        currentAttack.EndAttack();
        yield return new WaitForSeconds(currentAttack.endDelay);
        _playerControls.currentState = PlayerControls.ActionState.moving;
        comboTimer = 0;
    }

    

}
