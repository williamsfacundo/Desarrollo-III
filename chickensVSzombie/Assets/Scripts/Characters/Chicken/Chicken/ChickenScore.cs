using System;
using UnityEngine;
using ChickenVSZombies.GameplayItems;

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
        }

        private void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetScore;
        }

        public void AddScore(short value)
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