using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets 
{
    public class Bullet : MonoBehaviour //Change bullet for bullet movement
    {
        [SerializeField] private float _bulletVelocity = 6f;

        private float _bulletDamage = 0; // Collision with zombies (not implemented)

        private Vector3 _bulletMoveDirection = Vector2.zero;

        public float BulletDamage 
        {
            set 
            {
                _bulletDamage = value;
            }
        }

        public Vector2 BulletMoveDirection 
        {
            set 
            {
                _bulletMoveDirection = value;
            }
        }        

        // Update is called once per frame
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