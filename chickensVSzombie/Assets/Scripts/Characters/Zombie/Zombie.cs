using UnityEngine;

namespace ChickenVSZombies.Characters.Zombies 
{
    public class Zombie : MonoBehaviour
    {
        [SerializeField] private float _initialZombieLife;
        
        private float _life;        

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