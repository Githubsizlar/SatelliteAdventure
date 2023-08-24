using Type;
using UnityEngine;

namespace InventoryScripts
{
    public class AppleSpawner : MonoBehaviour
    {
        public Apple applePrefab;
        public Transform[] spawnPoints;

        private Apple _currentApple;

        void Start()
        {
            SpawnApple();
        }

        void Update()
        {
            if (_currentApple == null)
            {
                SpawnApple();
            }
        }

        void SpawnApple()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;
            // _currentApple = Factory.Factory.Instance.CreateObject<Apple>();
            // _currentApple.transform.position = spawnPosition;
            _currentApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        }
    }
}