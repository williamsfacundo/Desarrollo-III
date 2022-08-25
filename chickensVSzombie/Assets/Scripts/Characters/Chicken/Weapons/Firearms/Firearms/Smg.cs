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

        public override void FireWeapon() //Cambiar shoot por fire
        {
            Debug.Log("Smg fired!");

            base.FireWeapon();
        }

        public override void ReloadWeapon()
        {
            base.ReloadWeapon();
        }
    }
}