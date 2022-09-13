using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets;
using ChickenVSZombies.Interfaces;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class ZombieHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _initialZombieLife;

        [SerializeField] private short _pointsGivenWhenKilled;

        public delegate void ZombieAction(short value);
        
        public static ZombieAction OnZombieDeath; 

        public static int ZombiesInstances = 0;

        private float _life;        

        void Start()
        {
            _life = _initialZombieLife;
            
            ZombiesInstances++;
        }

        private void OnDestroy()
        {            
            ZombiesInstances--;

            if (OnZombieDeath != null) 
            {
                OnZombieDeath(100);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Bullet")
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();

                ReceiveDamage(bullet.BulletDamage);

                Destroy(collision.gameObject);
            }
        }

        public void ReceiveDamage(float damage) 
        {
            _life -= damage;

            LifeReachedZero();
        }

        public void LifeReachedZero()
        {
            if (_life <= 0)
            {
                DestroyZombie();
            }
        }

        public void DestroyZombie() 
        {
            Destroy(gameObject);
        }                
    }
}