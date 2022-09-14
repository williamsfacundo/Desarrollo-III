using System;
using UnityEngine;
using ChickenVSZombies.Characters.Zombies;
using ChickenVSZombies.GameplayItems;

namespace ChickenVSZombies.Characters.Chicken 
{
    public class ChickenScore : MonoBehaviour
    {
        private short _score;

        public static event Action OnChickenScoreChanged;

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

        public void ResetScore()
        {
            _score = 0;

            if (OnChickenScoreChanged != null)
            {
                OnChickenScoreChanged();
            }
        }

        private void AddScore(short value)
        {
            _score += value;

            if (OnChickenScoreChanged != null)
            {
                OnChickenScoreChanged();
            }
        }        
    }
}