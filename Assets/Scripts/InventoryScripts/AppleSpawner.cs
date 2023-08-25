using Type;
using UnityEngine;

namespace InventoryScripts
{
    public class AppleSpawner : MonoBehaviour
    {
        public Apple applePrefab;
        public Transform[] spawnPoints;

        private Apple _currentApple;
        private bool _isCurrentAppleNull;

        void Start()
        {
            _isCurrentAppleNull = _currentApple == null;
            SpawnApple();
        }

        void Update()
        {
            if (_isCurrentAppleNull)
            {
                SpawnApple();
            }
        }

        void SpawnApple()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;
            _currentApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        }
    }
}