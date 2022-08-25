namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts
{
    public class Magazine
    {
        private short _bulletsInMagazine;

        private short _magazineCapacity;

        private float _reloadTime;        

        public short BulletsInMagazine
        {
            set 
            {
                _bulletsInMagazine = value;
            }
            get
            {
                return _bulletsInMagazine;
            }
        }

        public short MagazineCapacity 
        {
            get
            {
                return _magazineCapacity;
            }
        }

        public float ReloadTime 
        {
            get 
            {
                return _reloadTime;
            }
        }

        public short BulletsNeededToFillMagazine 
        {
            get 
            {
                return (short)(_magazineCapacity - _bulletsInMagazine);
            }
        }

        public Magazine(short magazineSize, float reloadTime)
        {
            _bulletsInMagazine = magazineSize;

            _magazineCapacity = magazineSize;

            _reloadTime = reloadTime;            
        }        

        public bool MagazineEmpty()
        {
            return _bulletsInMagazine <= 0;
        }        

        public bool IsMagazineAbleToBeReloaded() 
        {
            return _bulletsInMagazine < _magazineCapacity;
        }
    }
}