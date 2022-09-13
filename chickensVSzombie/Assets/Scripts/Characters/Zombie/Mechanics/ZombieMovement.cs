using UnityEngine;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.Characters.Zombies 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float _zombieMoveVelocity;

        private GameObject _target;

        private Rigidbody2D _rb2D;

        private bool _isZombieCollidingWithTarget;

        public GameObject Target 
        {
            get 
            {
                return _target;
            }
        }

        public bool IsZombieCollidingWithTarget 
        {
            get 
            {
                return _isZombieCollidingWithTarget;
            }
        }

        void Awake() //What happens if the target was not found?
        {            
            _target = FindObjectOfType<BaseHealth>().gameObject;

            _rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _isZombieCollidingWithTarget = false;
        }

        void FixedUpdate()
        {
            MoveTowardsTheTarget();            
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base")
            {
                _isZombieCollidingWithTarget = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base")
            {
                _isZombieCollidingWithTarget = false;
            }
        }

        private void MoveTowardsTheTarget() 
        {
            if (!_isZombieCollidingWithTarget) 
            {
                _rb2D.MovePosition(gameObject.transform.position + 
                    CalculateDirectionToMoveTowardsTheTarget() * Time.deltaTime * _zombieMoveVelocity);                
            }            
        }

        private Vector3 CalculateDirectionToMoveTowardsTheTarget() 
        {
            return Vector3.Normalize(_target.gameObject.transform.position - gameObject.transform.position);
        }        
    }
}