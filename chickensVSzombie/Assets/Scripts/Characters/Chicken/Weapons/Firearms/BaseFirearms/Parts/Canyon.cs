namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts
{
    public class Canyon
    {
        private float _fireRate;

        private float _damage;

        private short _fireCapacity; //Amount of bullets that are shot in a single round

        public float FireRate 
        {
            get 
            {
                return _fireRate;
            }
        }

        public float Damage 
        {
            get 
            {
                return _damage;
            }
        }

        public short FireCapacity 
        {
            get 
            {
                return _fireCapacity;
            }
        }

        public Canyon(float fireRate, float damage, short fireCapacity)
        {
            _fireRate = fireRate;

            _damage = damage;

            _fireCapacity = fireCapacity;
        }
    }
}