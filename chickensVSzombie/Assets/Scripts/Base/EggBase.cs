using System;
using UnityEngine;

namespace ChickenVSZombies.Base 
{
    public class EggBase : MonoBehaviour 
    {
        [SerializeField] private float _initialBaseLife;

        public static event Action OnBaseDestroyed;

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
            _baseLife = _initialBaseLife; 
        }

        public void ReceiveDamage(float damage) 
        {
            _baseLife -= damage;            

            if (_baseLife <= 0) 
            {
                if (OnBaseDestroyed != null) 
                {
                    OnBaseDestroyed();
                }               
            }
        }
    }
}