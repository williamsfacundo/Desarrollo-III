using UnityEngine;
//using ChickenVSZombies.Base;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float _zombieMoveVelocity;

        private GameObject _target;

        private bool _isZombieCollidingWithBase;

        void Awake()
        {            
            _target = FindObjectOfType<Base.Base>().gameObject;            
        }

        private void Start()
        {
            _isZombieCollidingWithBase = false;
        }

        void Update()
        {
            MoveTowardsTheTarget();            
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base")
            {
                _isZombieCollidingWithBase = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base")
            {
                _isZombieCollidingWithBase = false;
            }
        }

        private void MoveTowardsTheTarget() 
        {
            if (!_isZombieCollidingWithBase) 
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