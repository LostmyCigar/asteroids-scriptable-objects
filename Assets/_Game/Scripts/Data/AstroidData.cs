using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new AstroidData", menuName = "ScriptableObjects/Data/AstroidData")]
public class AstroidData : ScriptableObject
{
    [Header("Asteroid Prefab")]
    public Asteroid _asteroidPrefab;
    [Space]

    [Header("Asteroid Spawn Settings")]

    public Vector2[] spawnPositions;

    [Range(0.5f, 4f)]
    [Tooltip("The minimum time between astroid wave spawns")]
    public float _minSpawnTime;
    [Range(2f, 7f)]
    [Tooltip("The maximum time between astroid wave spawns")]
    public float _maxSpawnTime;

    [Range(1f, 5f)]
    [Tooltip("The minimum amount of asteroids spawned in a wave")]
    public int _minSpawnAmount;
    [Range(1f, 10f)]
    [Tooltip("The maximum amount of asteroids spawned in a wave")]
    public int _maxSpawnAmount;
    [Space]

    [Header("Asteroid Appearance")]
    public Sprite[] astroidSprites;
    public Color[] astroidColors;
    [Space]

    [Header("Asteroid Settings")]
    [Range(1f, 4f)]
    [Tooltip("The minimum amount of force an astroid can spawn with")]
    public float _minForce;
    [Range(3f, 8f)]
    [Tooltip("The maximum amount of force an astroid can spawn with")]
    public float _maxForce;
    [Range(0.1f, 1f)]
    [Tooltip("The minimum size of an asteroid")]
    public float _minSize;
    [Range(0.8f, 2f)]
    [Tooltip("The maximum size of an asteroid")]
    public float _maxSize;
    [Range(0.1f, 0.8f)]
    [Tooltip("The minimum amount of torque an astroid can spawn with")]
    public float _minTorque;
    [Range(0.5f, 1.3f)]
    [Tooltip("The maximum amount of torque an astroid can spawn with")]
    public float _maxTorque;

}
