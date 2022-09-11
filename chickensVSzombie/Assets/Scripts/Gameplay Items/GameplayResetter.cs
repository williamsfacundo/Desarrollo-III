using System;
using UnityEngine;
using ChickenVSZombies.Characters.Chicken;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.GameplayItems 
{
    public class GameplayResetter : MonoBehaviour
    {
        public static event Action OnGameplayResset;       

        void OnEnable()
        {
            Chicken.OnChickenDeath += ResetGameplay;

            EggBase.OnBaseDestroyed += ResetGameplay;

            EndGameTimer.OnTimerEnds += ResetGameplay;
        }

        void OnDisable()
        {
            Chicken.OnChickenDeath -= ResetGameplay;

            EggBase.OnBaseDestroyed -= ResetGameplay;

            EndGameTimer.OnTimerEnds -= ResetGameplay;
        }

        private void ResetGameplay()
        {
            if (OnGameplayResset != null) 
            {
                OnGameplayResset();
            }
        }
    }
}