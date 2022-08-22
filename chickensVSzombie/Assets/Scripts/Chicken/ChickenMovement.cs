using UnityEngine;
using ChickenVSZombies.Characters.Movement;

namespace ChickenVSZombies 
{
    namespace Characters 
    {
        namespace Chicken
        {
            namespace Movement
            {
                public class ChickenMovement : MonoBehaviour
                {
                    [SerializeField] private float _chickenMoveVelocity;

                    private Direction _chickenMoveDirection;                   

                    private float _horizontalInputDetection;
                    private float _verticalInputDetection;                    

                    void Start()
                    {
                        _chickenMoveDirection = Direction.NONE;

                        _horizontalInputDetection = 0f;
                        _verticalInputDetection = 0f;
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
                        _verticalInputDetection = Input.GetAxisRaw("Vertical");

                        _horizontalInputDetection = Input.GetAxisRaw("Horizontal");
                    }

                    private void InputResponse() 
                    {
                        CalculateChickenMoveDirection();

                        MoveChicken();
                    }

                    private void CalculateChickenMoveDirection() 
                    {                        
                        if (_horizontalInputDetection == 0f && _verticalInputDetection == 1f) //UP
                        {
                            _chickenMoveDirection = Direction.UP;
                        }
                        else if (_horizontalInputDetection == 1f && _verticalInputDetection == 1f) //RIGHT_UP 
                        {
                            _chickenMoveDirection = Direction.RIGHT_UP;
                        }
                        else if (_horizontalInputDetection == 1f && _verticalInputDetection == 0f) //RIGHT
                        {
                            _chickenMoveDirection = Direction.RIGHT;
                        }
                        else if (_horizontalInputDetection == 1f && _verticalInputDetection == -1f) //RIGHT_DOWN
                        {
                            _chickenMoveDirection = Direction.RIGHT_DOWN;
                        }
                        else if (_horizontalInputDetection == 0f && _verticalInputDetection == -1f) //DOWN
                        {
                            _chickenMoveDirection = Direction.DOWN;
                        }
                        else if (_horizontalInputDetection == -1f && _verticalInputDetection == -1f) //LEFT_DOWN
                        {
                            _chickenMoveDirection = Direction.LEFT_DOWN;
                        }
                        else if (_horizontalInputDetection == -1f && _verticalInputDetection == 0f) //LEFT
                        {
                            _chickenMoveDirection = Direction.LEFT;
                        }
                        else if (_horizontalInputDetection == -1f && _verticalInputDetection == 1f) //LEFT_UP
                        {
                            _chickenMoveDirection = Direction.LEFT_UP;
                        }
                        else 
                        {
                            _chickenMoveDirection = Direction.NONE;
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
        }
    }    
}