using UnityEngine;
using ChickenVSZombies.GameplayItems;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class ZombiesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _zombiePrefab;

        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private float _minSpawnTime;
        
        [SerializeField] private float _maxSpawnTime;

        [SerializeField] private short _initialZombieMaxInstances;
        
        private ZombieHealth[] _zombieInstances;
        
        private float _newZombieSpawnTimer;        

        void Start()
        {
            SetRandomSpawnTimer();
            
            _zombieInstances = new ZombieHealth[_initialZombieMaxInstances];            
        }

        void Update()
        {
            DecreaseNewZombieSpawnTimer();

            InstanciateZombieIfTimerReachedZero();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetZombiesSpawner;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayResset += ResetZombiesSpawner;
        }

        private void ResetZombiesSpawner() 
        {
            SetRandomSpawnTimer();

            DestroyZombiesInScene();
        }

        private void DestroyZombiesInScene() 
        {
            for (short i = 0; i < _zombieInstances.Length; i++) 
            {
                if (_zombieInstances[i] != null) 
                {
                    _zombieInstances[i].DestroyZombie();
                }
            }
        }

        private void SetRandomSpawnTimer() 
        {
            _newZombieSpawnTimer = Random.Range(_minSpawnTime, _maxSpawnTime); 
        }

        private void DecreaseNewZombieSpawnTimer() 
        {
            if (_newZombieSpawnTimer > 0f && AreLessZombiesThanAllowed()) 
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

        private void InstanciateZombie(Vector3 position) // 
        {
            _zombieInstances[GetZombieInstancesNullIndex()] = Instantiate(_zombiePrefab, position, Quaternion.identity).GetComponent<ZombieHealth>();
        }
        
        private short  GetZombieInstancesNullIndex() 
        {
            short index = 0;

            for (short i = 0; i < _zombieInstances.Length; i++) 
            {
                if (_zombieInstances[i] == null) 
                {
                    return i;
                }
            }

            return index;
        }

        private bool AreLessZombiesThanAllowed() 
        {
            return ZombieHealth.ZombiesInstances < _initialZombieMaxInstances;
        }
    }
}