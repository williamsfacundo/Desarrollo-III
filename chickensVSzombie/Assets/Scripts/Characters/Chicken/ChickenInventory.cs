using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms;
using ChickenVSZombies.GameplayItems;

namespace ChickenVSZombies.Characters.Chicken
{
    public class ChickenInventory : MonoBehaviour
    {
        private Firearm _equippedWeapon;

        public Firearm EquippedWeapon 
        {
            get 
            {
                return _equippedWeapon;
            }
        }

        void Start()
        {
            ResetInventory();
        }

        private void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetInventory;
        }

        private void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetInventory;
        }

        private void ResetInventory() 
        {
            _equippedWeapon = new Rifle();
        }
    }
}