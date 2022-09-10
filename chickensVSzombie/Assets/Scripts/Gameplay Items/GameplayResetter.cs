using UnityEngine;
using ChickenVSZombies.Characters.Chicken;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.GameplayItems 
{
    public class GameplayResetter : MonoBehaviour
    {
        void OnEnable()
        {
            Chicken.OnChickenDeath += ResetGameplay;

            Base.Base.OnBaseDestroyed += ResetGameplay;

            EndGameTimer.OnTimerEnds += ResetGameplay;
        }

        void OnDisable()
        {
            Chicken.OnChickenDeath -= ResetGameplay;

            Base.Base.OnBaseDestroyed -= ResetGameplay;

            EndGameTimer.OnTimerEnds -= ResetGameplay;
        }

        private void ResetGameplay()
        {
            Debug.Log("Juego reseteado");
        }
    }
}