using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ShipData", menuName = "ScriptableObjects/Data/ShipData")]
public class PlayerData : ScriptableObject
{
    [Header("Engine")]
    public float _throttlePower;
    public float _rotationPower;
    [Space]

    [Header("Ship")]
    public int _startHealth;
    [Space]

    [Header("Gun")]
    public float _laserSpeed;
}
