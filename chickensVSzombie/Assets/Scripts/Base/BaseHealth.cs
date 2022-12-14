using System;
using UnityEngine;
using ChickenVSZombies.GameplayItems;
using ChickenVSZombies.Interfaces;

namespace ChickenVSZombies.Base 
{
    public class BaseHealth : MonoBehaviour, IDamageable 
    {
        [SerializeField] private float _initialBaseLife;

        public static event Action OnBaseDestroyed;

        public static event Action OnBaseHealthChanged;

        private float _baseLife;        

        public float BaseLife 
        {           
            get
            {
                return _baseLife;
            }
        }
        
        void Start()
        {
            ResetEggBase(); 
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetEggBase;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetEggBase;
        }

        public void ReceiveDamage(float damage) 
        {
            _baseLife -= damage;

            if (OnBaseHealthChanged != null)
            {
                OnBaseHealthChanged();
            }

            LifeReachedZero();
        }

        public void LifeReachedZero()
        {
            if (_baseLife <= 0)
            {
                if (OnBaseDestroyed != null)
                {
                    OnBaseDestroyed();
                }
            }
        }

        private void ResetEggBase() 
        {
            _baseLife = _initialBaseLife;

            if (OnBaseHealthChanged != null) 
            {
                OnBaseHealthChanged();
            }
        }        
    }
}