using UnityEngine;
using ChickenVSZombies.Characters.Enums;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    [RequireComponent(typeof(Chicken))]
    public class ChickenMovement : MonoBehaviour
    {
        [SerializeField] private float _chickenMoveVelocity;

        private Chicken _chicken;

        private Direction _chickenMoveDirection;

        private short _horizontalInputDetection;

        private short _verticalInputDetection;

        private void Awake()
        {
            _chicken = GetComponent<Chicken>();
        }

        void Start()
        {
            _chickenMoveDirection = Direction.NONE;

            _horizontalInputDetection = 0;
            _verticalInputDetection = 0;
        }

        void Update()
        {
            InputDetection();
        }

        void FixedUpdate()
        {
            InputResponse();
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

                    transform.position += new Vector3(0f, _chickenMoveVelocity) * Time.deltaTime;
                    break;
                case Direction.RIGHT_UP:

                    transform.position += new Vector3(_chickenMoveVelocity, _chickenMoveVelocity) * Time.deltaTime;
                    break;
                case Direction.RIGHT:

                    transform.position += new Vector3(_chickenMoveVelocity, 0f) * Time.deltaTime;
                    break;
                case Direction.RIGHT_DOWN:

                    transform.position += new Vector3(_chickenMoveVelocity, -_chickenMoveVelocity) * Time.deltaTime;
                    break;
                case Direction.DOWN:

                    transform.position += new Vector3(0f, -_chickenMoveVelocity) * Time.deltaTime;
                    break;
                case Direction.LEFT_DOWN:

                    transform.position += new Vector3(-_chickenMoveVelocity, -_chickenMoveVelocity) * Time.deltaTime;
                    break;
                case Direction.LEFT:

                    transform.position += new Vector3(-_chickenMoveVelocity, 0f) * Time.deltaTime;
                    break;
                case Direction.LEFT_UP:

                    transform.position += new Vector3(-_chickenMoveVelocity, _chickenMoveVelocity) * Time.deltaTime;
                    break;
                default:

                    break;
            }
        }
    }
}