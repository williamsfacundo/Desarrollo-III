using UnityEngine;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    //[RequireComponent(typeof(Chicken))]
    //[RequireComponent(typeof(ChickenInventory))]
    public class ChickenReloading : MonoBehaviour
    {
        private Chicken _chicken;

        private ChickenInventory _chickenInventory;

        private const KeyCode ReloadButton = KeyCode.R;

        private float _reloadingTimer;

        private bool _watingToReload;

        public bool WatingToReload 
        {
            get 
            {
                return _watingToReload;
            }
        }

        void Awake()
        {
            _chicken = GetComponent<Chicken>();

            _chickenInventory = GetComponent<ChickenInventory>();
        }

        private void Start()
        {
            _reloadingTimer = 0;

            _watingToReload = false;
        }

        void Update()
        {
            if (_watingToReload) 
            {
                DecreasReloadingTimer();

                Reload();
            }
            else 
            {
                StartReloadingMechanic();
            }
        }        

        private void StartReloadingMechanic()
        {
            if (Input.GetKeyDown(ReloadButton))
            {
                if (!_chicken.IsChickenDead() && _chickenInventory.EquippedWeapon.Magazine.IsMagazineAbleToBeReloaded() 
                    && _chickenInventory.EquippedWeapon.AmmoBag.IsThereAnyAmmoLeft())
                {
                    _reloadingTimer = _chickenInventory.EquippedWeapon.Magazine.ReloadTime;

                    _watingToReload = true;
                }
            }
        }

        private void DecreasReloadingTimer()
        {
            if (_reloadingTimer > 0f) 
            {
                _reloadingTimer -= Time.deltaTime;

                if (_reloadingTimer < 0f) 
                {
                    _reloadingTimer = 0;
                }
            }            
        } 
        
        private void Reload() 
        {
            if (_reloadingTimer == 0f) 
            {
                _chickenInventory.EquippedWeapon.ReloadWeapon();

                _watingToReload = false;
            }           
        }        
    }
}