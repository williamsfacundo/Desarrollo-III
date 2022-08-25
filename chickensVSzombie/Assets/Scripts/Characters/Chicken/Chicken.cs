using System;
using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Interfaces;

namespace ChickenVSZombies.Characters.Chicken
{
    public class Chicken : MonoBehaviour
    {
        [SerializeField] private float _initialLife;

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

            _life = _initialLife;

            _score = 0;

            _equippedItem = _chickenInventory.Items[0];
        }

        void Update()
        {
            //ChangeInventoryItem();

            ChickenDied();
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
                OnChickenDeath();
            }
        }

        /*private void ChangeInventoryItem() 
        {
            if (_life > 0f) 
            {
                //Change the object in the hand with other of the inventory
            }
        }*/
    }
}