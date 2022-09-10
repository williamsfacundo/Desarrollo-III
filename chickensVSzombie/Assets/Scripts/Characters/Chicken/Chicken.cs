using System;
using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Interfaces;

namespace ChickenVSZombies.Characters.Chicken
{
    public class Chicken : MonoBehaviour //Change for chickenHealth (fist separe what is health from what is score)
    {
        [SerializeField] private float _initialChickenLife;        

        private ChickenInventory _chickenInventory;

        private float _life;

        private short _score; // Show score in UI (not implemented)

        private IEquippableItem _equippedItem;

        public static event Action OnChickenDeath;                            

        public short Score
        {
            get
            {
                return _score;
            }
        }

        public IEquippableItem EquippedItem
        {
            get
            {
                return _equippedItem;
            }
        }

        void Awake()
        {
            _chickenInventory = new ChickenInventory();            
        }

        private void Start()
        {
            _life = _initialChickenLife;

            _score = 0;

            _equippedItem = _chickenInventory.Items[0];            
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