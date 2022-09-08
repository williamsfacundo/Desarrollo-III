using System;
using UnityEngine;

namespace ChickenVSZombies.Base 
{
    public class Base : MonoBehaviour //Change name for EggBase
    {
        [SerializeField] private float _initialBaseLife;

        private float _baseLife;

        //public static event Action OnBaseDestroyed;

        public float BaseLife 
        {           
            get
            {
                return _baseLife;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _baseLife = _initialBaseLife; 
        }

        public void ReceiveDamage(float damage) 
        {
            _baseLife -= damage;            

            if (_baseLife <= 0) 
            {
                Application.Quit();
                //OnBaseDestroyed();
            }
        }
    }
}