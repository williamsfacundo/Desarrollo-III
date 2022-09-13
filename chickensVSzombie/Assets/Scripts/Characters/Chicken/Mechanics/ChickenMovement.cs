using System;
using UnityEngine;
using ChickenVSZombies.Characters.Enums;
using ChickenVSZombies.GameplayItems;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    //[RequireComponent(typeof(Chicken))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ChickenMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _initialPosition;

        [SerializeField] private float _chickenMoveVelocity;

        private Rigidbody2D _rb2D;

        private ChickenHealth _chicken;

        public static event Action OnChickenMoved; 

        private Direction _chickenMoveDirection;

        private Vector3 _lastChickenPosition;

        private short _horizontalInputDetection;

        private short _verticalInputDetection;        

        private void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();

            _chicken = GetComponent<ChickenHealth>();
        }

        void Start()
        {
            ResetMovement();            
        }

        void Update()
        {
            InputDetection();            
        }

        void FixedUpdate()
        {
            InputResponse();

            ChickenChangedPosition();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetMovement;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetMovement;
        }

        private void ResetMovement() 
        {
            _rb2D.velocity = Vector2.zero;

            transform.position = _initialPosition.transform.position;

            if (OnChickenMoved != null)
            {
                OnChickenMoved();
            }

            _lastChickenPosition = transform.position;

            _chickenMoveDirection = Direction.NONE;

            _horizontalInputDetection = 0;
            _verticalInputDetection = 0;
        }

        private void InputDetection()
        {
            _horizontalInputDetection = (short)Input.GetAxisRaw("Horizontal");

            _verticalInputDetection = (short)Input.GetAxisRaw("Vertical");                        
        }

        private bool IsChickenMoving() 
        {
            return _horizontalInputDetection != 0 || _verticalInputDetection != 0;
        }

        private void InputResponse()
        {
            if (!_chicken.IsChickenDead()) 
            {
                if (IsChickenMoving()) 
                {
                    CalculateChickenMoveDirection();
                }
                else if (_chickenMoveDirection != Direction.NONE)
                {
                    _chickenMoveDirection = Direction.NONE;
                }

                if (_chickenMoveDirection != Direction.NONE) 
                { 
                    MoveChicken();                                      
                }
            }            
        }

        private void CalculateChickenMoveDirection() //Tener cuidado con los float al igualarlos
        {           
            if (_horizontalInputDetection == 0 && _verticalInputDetection == 1) //UP
            {
                _chickenMoveDirection = Direction.UP;
            }
            else if (_horizontalInputDetection == 1 && _verticalInputDetection == 1) //RIGHT_UP 
            {
                _chickenMoveDirection = Direction.RIGHT_UP;
            }
            else if (_horizontalInputDetection == 1 && _verticalInputDetection == 0) //RIGHT
            {
                _chickenMoveDirection = Direction.RIGHT;
            }
            else if (_horizontalInputDetection == 1 && _verticalInputDetection == -1) //RIGHT_DOWN
            {
                _chickenMoveDirection = Direction.RIGHT_DOWN;
            }
            else if (_horizontalInputDetection == 0 && _verticalInputDetection == -1) //DOWN
            {
                _chickenMoveDirection = Direction.DOWN;
            }
            else if (_horizontalInputDetection == -1 && _verticalInputDetection == -1) //LEFT_DOWN
            {
                _chickenMoveDirection = Direction.LEFT_DOWN;
            }
            else if (_horizontalInputDetection == -1 && _verticalInputDetection == 0) //LEFT
            {
                _chickenMoveDirection = Direction.LEFT;
            }
            else if (_horizontalInputDetection == -1 && _verticalInputDetection == 1) //LEFT_UP
            {
                _chickenMoveDirection = Direction.LEFT_UP;
            }            
        }

        private void MoveChicken()
        {            
            switch (_chickenMoveDirection)
            {
                case Direction.UP:

                    _rb2D.MovePosition(transform.position + new Vector3(0f, _chickenMoveVelocity) * Time.deltaTime);                    
                    break;
                case Direction.RIGHT_UP:

                    _rb2D.MovePosition(transform.position + new Vector3(_chickenMoveVelocity, _chickenMoveVelocity) * Time.deltaTime);
                    break;
                case Direction.RIGHT:

                    _rb2D.MovePosition(transform.position + new Vector3(_chickenMoveVelocity, 0f) * Time.deltaTime);
                    break;
                case Direction.RIGHT_DOWN:

                    _rb2D.MovePosition(transform.position + new Vector3(_chickenMoveVelocity, -_chickenMoveVelocity) * Time.deltaTime);
                    break;
                case Direction.DOWN:

                    _rb2D.MovePosition(transform.position + new Vector3(0f, -_chickenMoveVelocity) * Time.deltaTime);
                    break;
                case Direction.LEFT_DOWN:

                    _rb2D.MovePosition(transform.position + new Vector3(-_chickenMoveVelocity, -_chickenMoveVelocity) * Time.deltaTime);
                    break;
                case Direction.LEFT:

                    _rb2D.MovePosition(transform.position + new Vector3(-_chickenMoveVelocity, 0f) * Time.deltaTime);
                    break;
                case Direction.LEFT_UP:

                    _rb2D.MovePosition(transform.position + new Vector3(-_chickenMoveVelocity, _chickenMoveVelocity) * Time.deltaTime);
                    break;
                default:
                    break;
            }
        }

        private void ChickenChangedPosition()
        {
            if (_lastChickenPosition != transform.position)
            {
                if (OnChickenMoved != null)
                {
                    OnChickenMoved();
                }

                _lastChickenPosition = transform.position;
            }
        }
    }
}