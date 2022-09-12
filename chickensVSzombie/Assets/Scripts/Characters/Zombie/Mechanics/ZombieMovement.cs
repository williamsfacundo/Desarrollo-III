using UnityEngine;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float _zombieMoveVelocity;

        private GameObject _target;

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
        }

        private void Start()
        {
            _isZombieCollidingWithTarget = false;
        }

        void Update()
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
                gameObject.transform.position += CalculateDirectionToMoveTowardsTheTarget() * Time.deltaTime * _zombieMoveVelocity;
            }            
        }

        private Vector3 CalculateDirectionToMoveTowardsTheTarget() 
        {
            return Vector3.Normalize(_target.gameObject.transform.position - gameObject.transform.position);
        }        
    }
}