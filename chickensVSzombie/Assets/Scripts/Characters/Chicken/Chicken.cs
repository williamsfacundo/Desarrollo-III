using System;
using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken
{
    public class Chicken : MonoBehaviour //Change for chickenHealth (fist separe what is health from what is score)
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

        private void Start()
        {
            _life = _initialChickenLife;

            _score = 0;                      
        }       

        public bool IsChickenDead()
        {
            return _life <= 0f;
        }

        public void AddScore(short value)
        {
            _score += value;
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

        public void ReceiveDamage(float amountOfDamage) //Function repeats in Zombie als
        { 
            _life -= amountOfDamage;           

            ChickenDied();
        }        
    }
}