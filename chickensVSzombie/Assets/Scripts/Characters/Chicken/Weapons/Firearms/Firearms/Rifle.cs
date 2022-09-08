using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Stats;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms
{
    public class Rifle : Firearm
    {
        public Rifle() : base(
            new AmmoBag(true),
            new Canyon(RifleInitialStats.FireRate, RifleInitialStats.Damage, RifleInitialStats.FireCapacity),
            new Magazine(RifleInitialStats.MagazineSize, RifleInitialStats.ReloadTime))
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