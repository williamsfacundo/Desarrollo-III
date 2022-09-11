using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    //[RequireComponent(typeof(Chicken))]
    //[RequireComponent(typeof(ChickenReloading))]
    //[RequireComponent(typeof(ChickenInventory))]
    public class ChickenShooting : MonoBehaviour
    {
        private Chicken _chicken;

        private ChickenReloading _chickenReloading;
        
        private ChickenInventory _chickenInventory;

        private const int ShootingActionMouseButton = 0;

        void Awake()
        {
            _chicken = GetComponent<Chicken>();

            _chickenReloading = GetComponent<ChickenReloading>();

            _chickenInventory = GetComponent<ChickenInventory>();
        }

        void Update()
        {
            Shooting();
        }

        private void Shooting() //Fire rate mechanic not implemented
        {
            if (Input.GetMouseButtonDown(ShootingActionMouseButton))
            {
                if (!_chicken.IsChickenDead() && !_chickenReloading.WatingToReload 
                    && !_chickenInventory.EquippedWeapon.Magazine.MagazineEmpty())
                {                    
                    _chickenInventory.EquippedWeapon.FireWeapon(gameObject.transform.position);
                }               
            }
        }
    }
}