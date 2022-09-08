using UnityEngine;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class ZombiesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _zombiePrefab;

        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private float _minSpawnTime;
        
        [SerializeField] private float _maxSpawnTime;

        //[SerializeField] private float _maxZombiesSpawnInASingleRow;

        private float _newZombieSpawnTimer;

        void Start()
        {
            SetRandomSpawnTimer();            
        }

        void Update()
        {
            DecreaseNewZombieSpawnTimer();

            InstanciateZombieIfTimerReachedZero();
        }

        private void SetRandomSpawnTimer() 
        {
            _newZombieSpawnTimer = Random.Range(_minSpawnTime, _maxSpawnTime); 
        }

        private void DecreaseNewZombieSpawnTimer() 
        {
            if (_newZombieSpawnTimer > 0f) 
            {
                _newZombieSpawnTimer -= Time.deltaTime;

                if (_newZombieSpawnTimer < 0f) 
                {
                    _newZombieSpawnTimer = 0f;
                }
            }
        }

        private void InstanciateZombieIfTimerReachedZero() 
        {
            if (_newZombieSpawnTimer == 0f) 
            {
                Vector3 spawnPosition = GetRandomSpawnPoint();

                InstanciateZombie(spawnPosition);

                SetRandomSpawnTimer();
            }
        }

        private Vector3 GetRandomSpawnPoint() 
        {
            int random = Random.Range(0, _spawnPoints.Length);
            
            return _spawnPoints[random].transform.position;
        }

        private void InstanciateZombie(Vector3 position) 
        {
            Instantiate(_zombiePrefab, position, Quaternion.identity);
        }       
    }
}