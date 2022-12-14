using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets 
{
    public class Bullet : MonoBehaviour 
    {
        [SerializeField] private float _bulletVelocity;

        private float _bulletDamagee;        

        private Vector3 _bulletMoveDirection = Vector2.zero;        

        public float BulletDamage 
        {
            set 
            {
                _bulletDamagee = value;
            }
            get 
            {
                return _bulletDamagee;
            }
        }

        public Vector3 BulletMoveDirection 
        {
            set 
            {
                _bulletMoveDirection = value;
            }            
        }        

        void FixedUpdate()
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