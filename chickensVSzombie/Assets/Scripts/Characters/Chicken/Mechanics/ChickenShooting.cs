using UnityEngine;
using ChickenVSZombies.GameplayItems;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    //[RequireComponent(typeof(Chicken))]
    //[RequireComponent(typeof(ChickenReloading))]
    //[RequireComponent(typeof(ChickenInventory))]
    public class ChickenShooting : MonoBehaviour
    {
        private ChickenHealth _chicken;

        private ChickenReloading _chickenReloading;
        
        private ChickenInventory _chickenInventory;

        private const int ShootingActionMouseButton = 0;

        private float _fireRateTimer;

        public ChickenInventory ChickenInventory 
        {
            get 
            {
                return _chickenInventory;
            }
        }

        void Awake()
        {
            _chicken = GetComponent<ChickenHealth>();

            _chickenReloading = GetComponent<ChickenReloading>();

            _chickenInventory = GetComponent<ChickenInventory>();            
        }

        private void Start()
        {
            _fireRateTimer = 0f;

            Magazine.CallOnMagazineChanged();
        }

        void Update()
        {
            DecreaseFireRateTimer();

            Shooting();            
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayResset += ResetChickenShooting;            
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayResset -= ResetChickenShooting;
        }

        private void ResetChickenShooting() 
        {
            _fireRateTimer = 0f;           

            DestroyBulletsInScene();
        }
        
        private void DestroyBulletsInScene() 
        {
            Bullet[] bullets = FindObjectsOfType<Bullet>();

            for (short i = 0; i < bullets.Length; i++)
            {
                bullets[i].DestroyBullet();
            }
        }

        private void Shooting()
        {
            if (Input.GetMouseButton(ShootingActionMouseButton))
            {
                if (!_chicken.IsChickenDead() && !_chickenReloading.WatingToReload 
                    && !_chickenInventory.EquippedWeapon.Magazine.MagazineEmpty() &&
                    _fireRateTimer == 0f)
                {                    
                    _chickenInventory.EquippedWeapon.FireWeapon(gameObject.transform.position);

                    _fireRateTimer = _chickenInventory.EquippedWeapon.Canyon.FireRate;                   
                }               
            }
        }

        private void DecreaseFireRateTimer() 
        {
            if (_fireRateTimer > 0f) 
            {
                _fireRateTimer -= Time.deltaTime;

                if (_fireRateTimer < 0f) 
                {
                    _fireRateTimer = 0f;
                }
            }
        }
    }
}