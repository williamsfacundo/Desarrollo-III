using System;
using UnityEngine;
using ChickenVSZombies.Characters.Chicken;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.GameplayItems 
{
    public class GameplayResetter : MonoBehaviour
    {
        public static event Action OnGameplayResset;

        public static bool ResettingGameplay = false;       

        void OnEnable()
        {
            ChickenHealth.OnChickenDeath += ResetGameplay;

            BaseHealth.OnBaseDestroyed += ResetGameplay;

            EndGameTimer.OnTimerEnds += ResetGameplay;
        }

        void OnDisable()
        {
            ChickenHealth.OnChickenDeath -= ResetGameplay;

            BaseHealth.OnBaseDestroyed -= ResetGameplay;

            EndGameTimer.OnTimerEnds -= ResetGameplay;
        }

        private void ResetGameplay()
        {
            ResettingGameplay = true;

            if (OnGameplayResset != null) 
            {
                OnGameplayResset();                
            }

            ResettingGameplay = false;
        }
    }
}