namespace ChickenVSZombies.Interfaces 
{
    interface IDamageable
    {
        public void ReceiveDamage(float damage);

        public void Death();
    }
}