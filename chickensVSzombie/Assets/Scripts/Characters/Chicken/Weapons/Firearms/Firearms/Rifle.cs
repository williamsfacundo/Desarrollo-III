using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Stats;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms
{
    public class Rifle : Firearm
    {
        public Rifle() : base(
            new AmmoBag(RifleInitialStats.MaxAmmo),
            new Canyon(RifleInitialStats.FireRate, RifleInitialStats.Damage, RifleInitialStats.FireCapacity),
            new Magazine(RifleInitialStats.MagazineSize, RifleInitialStats.ReloadTime))
        {

        }

        public override void FireWeapon() //Cambiar shoot por fire
        {
            Debug.Log("Rifle fired!");

            base.FireWeapon();
        }

        public override void ReloadWeapon()
        {
            base.ReloadWeapon();
        }
    }
}