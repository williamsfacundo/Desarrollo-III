using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Firearm")]
    class FirearmStats : ScriptableObject 
    {
        public short MaxAmmo;

        public short FireCapacity;
        
        public short MagazineSize;
        
        public float FireRate;
        
        public float Damage;

        public float ReloadTime;
    }   
}