using System;
using UnityEngine;

namespace ChickenVSZombies.GameplayItems 
{
    public class EndGameTimer : MonoBehaviour
    {
        public static event Action OnTimerEnds; 

        private float _gameplayDuration;

        private float _endGameTimer; //In order not to repeat so many times timer creat a class timer

        void Start()
        {
            _gameplayDuration = 60f;

            _endGameTimer = _gameplayDuration;
        }

        void Update()
        {
            EndGame();
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
    }
}