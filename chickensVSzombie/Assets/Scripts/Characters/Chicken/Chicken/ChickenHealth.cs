using System;
using UnityEngine;
using ChickenVSZombies.GameplayItems;
using ChickenVSZombies.Interfaces;

namespace ChickenVSZombies.Characters.Chicken
{
    public class ChickenHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _initialChickenLife;    

        private float _life;                

        public static event Action OnChickenDeath;                

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

        public void ReceiveDamage(float damage)
        {
            _life -= damage;

            ChickenDied();
        }

        private void ResetChicken()
        {
            _life = _initialChickenLife;            
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