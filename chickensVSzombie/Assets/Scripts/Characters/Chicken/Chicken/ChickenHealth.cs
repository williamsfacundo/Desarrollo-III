using System;
using UnityEngine;
using ChickenVSZombies.GameplayItems;
using ChickenVSZombies.Interfaces;

namespace ChickenVSZombies.Characters.Chicken
{
    public class ChickenHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _initialChickenLife;    

        public static event Action OnChickenDeath;

        public static event Action OnHealthChanged;

        private float _life;

        public float Life 
        {
            get 
            {
                return _life;
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

        public void ReceiveDamage(float damage)
        {
            _life -= damage;

            if (OnHealthChanged != null)
            {
                OnHealthChanged();
            }

            LifeReachedZero();
        }

        public void LifeReachedZero()
        {
            if (_life <= 0f)
            {
                if (OnChickenDeath != null)
                {
                    OnChickenDeath();
                }
            }
        }

        private void ResetChicken()
        {
            _life = _initialChickenLife;

            if (OnHealthChanged != null) 
            {
                OnHealthChanged();
            }
        }        
    }
}