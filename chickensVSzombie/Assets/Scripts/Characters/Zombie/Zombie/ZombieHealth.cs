using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets;
using ChickenVSZombies.Interfaces;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class ZombieHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _initialZombieLife;
        
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
        }

        public void ReceiveDamage(float damage) 
        {
            _life -= damage;            

            if (_life <= 0) 
            {
                Destroy(gameObject);                
            }
        }

        public void DestroyZombie() 
        {
            Destroy(gameObject);
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
    }
}