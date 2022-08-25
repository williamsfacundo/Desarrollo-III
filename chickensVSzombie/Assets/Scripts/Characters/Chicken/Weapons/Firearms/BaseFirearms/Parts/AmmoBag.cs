namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts
{
    public class AmmoBag
    {
        private short _ammoLeft;

        private short _initialMaxAmmo;

        private bool _isAmmoInfinite;

        public short AmmoLeft 
        {
            set 
            {
                _ammoLeft = value;
            }
            get 
            {
                return _ammoLeft;
            }
        }

        public bool IsAmmoInfinite 
        {
            get 
            {
                return _isAmmoInfinite;
            }
        }

        public AmmoBag(short initialMaxAmmo)
        {
            _ammoLeft = initialMaxAmmo;

            _initialMaxAmmo = initialMaxAmmo;

            _isAmmoInfinite = false;
        }

        public AmmoBag(bool infiniteAmmo) //If I put false, infinite ammo will be also true
        {
            _ammoLeft = 0;

            _initialMaxAmmo = 0;

            _isAmmoInfinite = true;
        }

        public bool IsThereAnyAmmoLeft() 
        {
            return _isAmmoInfinite || _ammoLeft > 0;
        }
    }
}