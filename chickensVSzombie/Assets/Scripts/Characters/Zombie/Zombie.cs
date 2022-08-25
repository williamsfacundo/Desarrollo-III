using UnityEngine;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class Zombie : MonoBehaviour
    {
        private float _life;

        private GameObject target;

        void Start()
        {
            
        }
        
        void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget() 
        {

        }       

        public void ReceiveDamage(float amountOfDamage) 
        {
            _life -= amountOfDamage;

            if (_life <= 0) 
            {
                Debug.Log("Zombie died!");

                Destroy(gameObject);                
            }
        }
    }
}