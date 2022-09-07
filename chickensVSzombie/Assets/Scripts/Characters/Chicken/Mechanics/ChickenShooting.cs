using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    //[RequireComponent(typeof(Chicken))]
    //[RequireComponent(typeof(ChickenReloading))]
    public class ChickenShooting : MonoBehaviour
    {
        private Chicken _chicken;

        private ChickenReloading _chickenReloading;

        private const int ShootingActionMouseButton = 0;

        void Awake()
        {
            _chicken = GetComponent<Chicken>();

            _chickenReloading = GetComponent<ChickenReloading>();
        }

        void Update()
        {
            Shooting();
        }

        private void Shooting() //Fire rate mechanic not implemented
        {
            if (Input.GetMouseButtonDown(ShootingActionMouseButton))
            {
                if (_chicken.EquippedItem is Firearm && !_chicken.IsChickenDead() && !_chickenReloading.WatingToReload)
                {
                    Firearm auxFirearm = ((Firearm)_chicken.EquippedItem);

                    if (!auxFirearm.Magazine.MagazineEmpty()) 
                    {
                        auxFirearm.FireWeapon(gameObject.transform.position);
                    }                    
                }               
            }
        }
    }
}