using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets 
{
    public class Bullet : MonoBehaviour //Damage is harcoded, must be changed 
    {
        [SerializeField] private float _bulletVelocity;

        private float _bulletDamage;

        private Vector3 _bulletMoveDirection = Vector2.zero;        

        public float BulletDamage 
        {
            set 
            {
                _bulletDamage = value;
            }
            get 
            {
                return _bulletDamage;
            }
        }

        public Vector3 BulletMoveDirection 
        {
            set 
            {
                _bulletMoveDirection = value;
            }            
        }

        void Start()
        {
            _bulletDamage = 10;
        }
        
        void Update()
        {
            MoveBullet();
        }        

        public void DestroyBullet() 
        {
            Destroy(gameObject);
        }

        private void MoveBullet() 
        {            
            transform.position += _bulletMoveDirection * _bulletVelocity * Time.deltaTime;            
        }
    }
}