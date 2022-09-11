using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Stats;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms
{
    public class Smg : Firearm 
    {
        public Smg() : base(
            new AmmoBag(SmgInitialStats.MaxAmmo),
            new Canyon(SmgInitialStats.FireRate, SmgInitialStats.Damage, SmgInitialStats.FireCapacity),
            new Magazine(SmgInitialStats.MagazineSize, SmgInitialStats.ReloadTime))
        {

        }

        public override void FireWeapon(Vector3 playerPosition) //Cambiar shoot por fire
        {
            base.FireWeapon(playerPosition);
        }

        public override void ReloadWeapon()
        {
            base.ReloadWeapon();
        }
    }
}