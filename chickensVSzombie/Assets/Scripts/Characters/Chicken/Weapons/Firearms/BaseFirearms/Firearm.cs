using UnityEngine;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Bullets;

namespace ChickenVSZombies.Characters.Chicken.Weapons.Firearms
{
    public abstract class Firearm
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

            Vector3 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - playerPosition;
            
            direction.z = 0f;

            Vector3 normalizedDirection = Vector3.Normalize(direction);

            bulletScript.BulletMoveDirection = normalizedDirection;            

            _magazine.BulletsInMagazine -= _canyon.FireCapacity;            
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