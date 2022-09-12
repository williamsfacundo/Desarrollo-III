using System;
using UnityEngine;
using ChickenVSZombies.GameplayItems;

namespace ChickenVSZombies.Characters.Chicken
{
    public class Chicken : MonoBehaviour //Change for chickenHealth (first separe what is health from what is score)
    {
        [SerializeField] private float _initialChickenLife;    

        private float _life;

        private short _score; // Show score in UI (not implemented)        

        public static event Action OnChickenDeath;                            

        public short Score
        {
            get
            {
                return _score;
            }
        }                

        void Start()
        {
            ResetChicken();                      
        }

        private void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetChicken;
        }

        private void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetChicken;
        }

        public bool IsChickenDead()
        {
            return _life <= 0f;
        }

        public void AddScore(short value)
        {
            _score += value;
        }

        public void ReceiveDamage(float amountOfDamage) //Function repeats in Zombie als
        {
            _life -= amountOfDamage;

            ChickenDied();
        }

        private void ResetChicken()
        {
            _life = _initialChickenLife;

            _score = 0;
        }

        private void ChickenDied()
        {
            if (_life <= 0f)
            {
                if (OnChickenDeath != null)
                {                    
                    OnChickenDeath();
                }
            }
        }                
    }
}