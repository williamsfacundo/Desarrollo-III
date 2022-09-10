using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Mechanics;

namespace ChickenVSZombies.GameplayItems 
{
    public class CameraFollowsPlayer : MonoBehaviour
    {
        private ChickenMovement _chickenMovement;

        void Awake()
        {
            _chickenMovement = FindObjectOfType<ChickenMovement>();

            if (_chickenMovement == null) 
            {
                Debug.Log("There is no chicken in the scene");

                Destroy(this);
            }           
        }        

        private void OnEnable()
        {
            ChickenMovement.OnChickenMoved += UpdateCameraPosition;            
        }

        private void OnDisable()
        {
            ChickenMovement.OnChickenMoved -= UpdateCameraPosition;
        }       

        private void UpdateCameraPosition() 
        {
            transform.position = new Vector3(_chickenMovement.gameObject.transform.position.x,
                _chickenMovement.gameObject.transform.position.y, transform.position.z);                        
        }        
    }
}
