using System;
using UnityEngine;
using ChickenVSZombies.GameplayItems;
using ChickenVSZombies.Characters.Zombies;

namespace ChickenVSZombies.Characters.Chicken 
{
    public class ChickenScore : MonoBehaviour
    {
        private short _score;

        public static event Action OnChickenScoreUp;

        public short Score
        {
            get
            {
                return _score;
            }
        }

        void Start()
        {
            ResetScore();
        }

        private void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetScore;

            ZombieHealth.OnZombieDeath += AddScore;
        }

        private void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetScore;

            ZombieHealth.OnZombieDeath -= AddScore;
        }

        private void AddScore(short value)
        {
            _score += value;

            if (OnChickenScoreUp != null) 
            {
                OnChickenScoreUp();
            }
        }

        private void ResetScore() 
        {
            _score = 0;
        }
    }
}