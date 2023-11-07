using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    public PlayerInfo _playerInfo;

    private void Start()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }
    public void UpgradeHealth(float cost)
    {
        Debug.Log(_playerInfo.UpgradeMaxHealth(cost) ? "Upgrade bought" : "CANT AFFORD UPGRADE");
    }
    
    public void UpgradeCharge(float cost)
    {
        Debug.Log(_playerInfo.UpgradeMaxCharge(cost) ? "Upgrade bought" : "CANT AFFORD UPGRADE");
    }
    
    public void UpgradeRecharge(float cost)
    {
        Debug.Log(_playerInfo.UpgradeRechargeRate(cost) ? "Upgrade bought" : "CANT AFFORD UPGRADE");
    }
}
