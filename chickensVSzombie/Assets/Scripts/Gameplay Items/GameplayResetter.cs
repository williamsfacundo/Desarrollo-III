using UnityEngine;
using ChickenVSZombies.Characters.Chicken;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.GameplayItems 
{
    public class GameplayResetter : MonoBehaviour
    {
        private Chicken _chicken;
        private EggBase _eggBase;
        private EndGameTimer _endGameTimer;

        private void Awake()
        {
            _chicken = FindObjectOfType<Chicken>();
            _eggBase = FindObjectOfType<EggBase>();
            _endGameTimer = FindObjectOfType<EndGameTimer>();

            if (_chicken == null || _eggBase == null || _endGameTimer == null) 
            {
                Debug.Log("Error finding objects");
            }
        }

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
            
        }
    }
}