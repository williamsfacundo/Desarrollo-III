using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms;

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
            _equippedWeapon = new Rifle();
        }        
    }
}