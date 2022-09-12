using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;
using ChickenVSZombies.GameplayItems;

namespace ChickenVSZombies.Characters.Chicken
{
    public class ChickenInventory : MonoBehaviour
    {
        [SerializeField] private FirearmStats _initialFirearmStats;

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
            _equippedWeapon = new Firearm(
            new AmmoBag(true),
            new Canyon(_initialFirearmStats.FireRate, _initialFirearmStats.Damage, _initialFirearmStats.FireCapacity),
            new Magazine(_initialFirearmStats.MagazineSize, _initialFirearmStats.ReloadTime));
        }
    }
}