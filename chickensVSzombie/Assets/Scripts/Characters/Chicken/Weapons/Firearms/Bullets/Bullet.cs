using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets 
{
    public class Bullet : MonoBehaviour //Change bullet for bullet movement
    {
        [SerializeField] private float _bulletVelocity = 6f;

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

        public Vector2 BulletMoveDirection 
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

        private void MoveBullet() 
        {
            transform.position += _bulletMoveDirection * _bulletVelocity * Time.deltaTime;            
        }
    }
}