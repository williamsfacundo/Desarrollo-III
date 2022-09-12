using UnityEngine;
using ChickenVSZombies.Characters.Chicken;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.Characters.Zombies 
{
    [RequireComponent(typeof(ZombieMovement))]
    public class ZombieAttacking : MonoBehaviour //For now it only attacks the base
    {
        [SerializeField] private float _zombieInitialDamage;

        [SerializeField] private float _zombieAttackCooldownTime;

        private ZombieMovement _zombieMovement;

        private EggBase _base;

        private float _zombieDamage;

        private float _attackCooldownTimer;

        private bool _inAttackMode;

        void Awake()
        {            
            _zombieMovement = gameObject.GetComponent<ZombieMovement>();            
        }

        void Start()
        {
            _base = _zombieMovement.Target.GetComponent<EggBase>();

            _zombieDamage = _zombieInitialDamage;

            _attackCooldownTimer = 0f;

            _inAttackMode = false;            
        }

        void Update()
        {
            EnterAttackModeIfZombieIsInTarget();

            AttackTargetIfIsInAttackMode();

            DecreaseCooldownTimerIfZombieHasAttacked();           
        }

        private void EnterAttackModeIfZombieIsInTarget()        
        {
            if (_zombieMovement.IsZombieCollidingWithTarget && _attackCooldownTimer <= 0f) 
            {
                _inAttackMode = true;
            }
        }

        private void AttackTargetIfIsInAttackMode() 
        {
            if (_inAttackMode) 
            {
                _base.ReceiveDamage(_zombieDamage);

                _attackCooldownTimer = _zombieAttackCooldownTime;

                _inAttackMode = false;
            }
        }       

        private void DecreaseCooldownTimerIfZombieHasAttacked() 
        {
            if (_attackCooldownTimer > 0f) 
            {
                _attackCooldownTimer -= Time.deltaTime;

                if (_attackCooldownTimer < 0f) 
                {
                    _attackCooldownTimer = 0f;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.transform.tag == "Player" && _attackCooldownTimer == 0f) 
            {
                Chicken.ChickenHealth chicken = collision.gameObject.GetComponent<Chicken.ChickenHealth>();

                chicken.ReceiveDamage(_zombieDamage);

                _attackCooldownTimer = _zombieAttackCooldownTime;
            }
        }
    }
}