using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new AstroidData", menuName = "ScriptableObjects/Data/AstroidData")]
public class AstroidData : ScriptableObject
{
    public Asteroid _asteroidPrefab;
    public float _minSpawnTime;
    public float _maxSpawnTime;
    public int _minSpawnAmount;
    public int _maxSpawnAmount;
}
