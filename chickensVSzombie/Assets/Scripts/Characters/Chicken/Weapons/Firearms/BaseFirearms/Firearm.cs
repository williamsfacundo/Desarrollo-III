using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;
using ChickenVSZombies.Characters.Chicken.Interfaces;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms
{
    public abstract class Firearm : IEquippableItem
    {
        private AmmoBag _ammoBag;

        private Canyon _canyon;

        private Magazine _magazine;

        Camera _camera;

        public AmmoBag AmmoBag 
        {
            get 
            {
                return _ammoBag;
            }
        }

        public Canyon Canyon 
        {
            get
            {
                return _canyon;
            }
        }

        public Magazine Magazine 
        {
            get 
            {
                return _magazine;
            }
        }

        public Firearm(AmmoBag ammoBag, Canyon canyon, Magazine magazine)
        {
            _ammoBag = ammoBag;

            _canyon = canyon;

            _magazine = magazine;

            _camera = Camera.main;
        }

        public virtual void FireWeapon(Vector3 playerPosition)
        {
            GameObject bulletObject = GameObject.Instantiate<GameObject>((GameObject)Resources.Load("Bullet"));

            bulletObject.transform.position = playerPosition;
                        
            Bullet bulletScript = bulletObject.GetComponent<Bullet>();            

            bulletScript.BulletDamage = _canyon.Damage;           

            bulletScript.BulletMoveDirection = Vector3.Normalize(_camera.ScreenToWorldPoint(Input.mousePosition) - playerPosition); // Direction is not ok

            _magazine.BulletsInMagazine -= _canyon.FireCapacity;

            Debug.Log("Bullets: " + _magazine.BulletsInMagazine);
        }       

        public virtual void ReloadWeapon() 
        {
            if (_ammoBag.IsAmmoInfinite) 
            {
                _magazine.BulletsInMagazine = _magazine.MagazineCapacity;
            }
            else 
            {
                if (_ammoBag.AmmoLeft >= _magazine.BulletsNeededToFillMagazine)
                {
                    _ammoBag.AmmoLeft -= _magazine.BulletsNeededToFillMagazine;

                    _magazine.BulletsInMagazine = _magazine.MagazineCapacity;
                }
                else 
                {
                    _magazine.BulletsInMagazine += _ammoBag.AmmoLeft;

                    _ammoBag.AmmoLeft = 0;
                }
            }            
        }      
    }
}