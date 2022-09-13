using System;
using UnityEngine;

namespace ChickenVSZombies.GameplayItems 
{
    public class EndGameTimer : MonoBehaviour
    {        
        [SerializeField] private float _gameplayDuration;
        
        public static event Action OnTimerEnds;

        private float _endGameTimer; //In order not to repeat so many times timer creat a class timer

        public float Timer 
        {
            get 
            {
                return _endGameTimer;
            }
        }

        void Start()
        {
            ResetTimer();
        }

        void Update()
        {
            EndGame();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetTimer;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetTimer;
        }

        private void EndGame()
        {
            _endGameTimer -= Time.deltaTime;

            if (_endGameTimer <= 0f)
            {
                if (OnTimerEnds != null) 
                {
                    OnTimerEnds(); 
                }               
            }
        }

        private void ResetTimer() 
        {
            _endGameTimer = _gameplayDuration;
        }
    }
}