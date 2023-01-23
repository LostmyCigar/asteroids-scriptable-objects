using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private AstroidData _asteroidData;
        
        private float _timer;
        private float _nextSpawnTime;
        private Camera _camera;

        private enum SpawnLocation
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private void Start()
        {
            _camera = Camera.main;
            Spawn();
            UpdateNextSpawnTime();
        }

        private void Update()
        {
            UpdateTimer();

            if (!ShouldSpawn())
                return;

            Spawn();
            UpdateNextSpawnTime();
            _timer = 0f;
        }

        private void UpdateNextSpawnTime()
        {
            _nextSpawnTime = Random.Range(_asteroidData._minSpawnTime, _asteroidData._maxSpawnTime);
        }

        private void UpdateTimer()
        {
            _timer += Time.deltaTime;
        }

        private bool ShouldSpawn()
        {
            return _timer >= _nextSpawnTime;
        }

        private void Spawn()
        {
            var amount = Random.Range(_asteroidData._minSpawnAmount, _asteroidData._maxSpawnAmount + 1);
            
            for (var i = 0; i < amount; i++)
            {
                var position = GetSpawnLocation();
                Instantiate(_asteroidData._asteroidPrefab, position, Quaternion.identity);
            }
        }

        private Vector3 GetSpawnLocation()
        {
            var rand = Random.Range(0, _asteroidData.spawnPositions.Length);

            return _asteroidData.spawnPositions[rand];
        }

        //private Vector3 GetStartPosition(SpawnLocation spawnLocation)
        //{
        //    var pos = new Vector3 { z = Mathf.Abs(_camera.transform.position.z) };
            
        //    const float padding = 5f;
        //    switch (spawnLocation)
        //    {
        //        case SpawnLocation.Top:
        //            pos.x = Random.Range(0f, Screen.width);
        //            pos.y = Screen.height + padding;
        //            break;
        //        case SpawnLocation.Bottom:
        //            pos.x = Random.Range(0f, Screen.width);
        //            pos.y = 0f - padding;
        //            break;
        //        case SpawnLocation.Left:
        //            pos.x = 0f - padding;
        //            pos.y = Random.Range(0f, Screen.height);
        //            break;
        //        case SpawnLocation.Right:
        //            pos.x = Screen.width - padding;
        //            pos.y = Random.Range(0f, Screen.height);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(spawnLocation), spawnLocation, null);
        //    }
            
        //    return _camera.ScreenToWorldPoint(pos);
        //}

        private void OnDrawGizmos()
        {
            if (_asteroidData == null)
                return;

            if (_asteroidData.spawnPositions == null)
                return;

            Gizmos.color = Color.red;
            for (int i = 0; i < _asteroidData.spawnPositions.Length; i++)
            {
                Gizmos.DrawSphere(_asteroidData.spawnPositions[i], 0.5f);
            }
        }
    }
}
