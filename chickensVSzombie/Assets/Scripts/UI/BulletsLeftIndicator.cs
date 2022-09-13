using UnityEngine;
using TMPro;
using ChickenVSZombies.Characters.Chicken.Mechanics;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms.Parts;

namespace ChickenVSZombies.UI 
{
    public class BulletsLeftIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showBulletsLeftText;
        
        private ChickenShooting _chickenShooting;

        private void Awake()
        {
            _chickenShooting = FindObjectOfType<ChickenShooting>();
        }

        private void OnEnable()
        {
            Magazine.OnMagazineChanged += UpdateBulletsLeftText;            
        }

        private void OnDisable()
        {
            Magazine.OnMagazineChanged += UpdateBulletsLeftText;            
        }

        private void UpdateBulletsLeftText()
        {            
            _showBulletsLeftText.text = "Bullets Left: " + _chickenShooting.ChickenInventory.EquippedWeapon.Magazine.BulletsInMagazine;
        }
    }
}