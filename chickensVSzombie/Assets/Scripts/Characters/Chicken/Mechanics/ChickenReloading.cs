using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms;

namespace ChickenVSZombies.Characters.Chicken.Mechanics
{
    [RequireComponent(typeof(Chicken))]
    public class ChickenReloading : MonoBehaviour
    {
        private Chicken _chicken;

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
                if (_chicken.EquippedItem is Firearm && !_chicken.IsChickenDead())
                {
                    Firearm auxFirearm = ((Firearm)_chicken.EquippedItem);

                    if (auxFirearm.Magazine.IsMagazineAbleToBeReloaded() && auxFirearm.AmmoBag.IsThereAnyAmmoLeft())
                    {
                        _reloadingTimer = auxFirearm.Magazine.ReloadTime;

                        _watingToReload = true;
                    }                   
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
                ((Firearm)_chicken.EquippedItem).ReloadWeapon();

                _watingToReload = false;
            }           
        }        
    }
}