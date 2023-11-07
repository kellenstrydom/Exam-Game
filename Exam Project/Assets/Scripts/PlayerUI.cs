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

    public PlayerInfo _playerInfo;

    void Update()
    {
        healthSlider.value = (int)(_playerInfo.HealthPoints / _playerInfo.MaxHealthPoints * 100);
        chargeSlider.value = (int)(_playerInfo.charge / _playerInfo.maxCharge * 100);
    }
}
