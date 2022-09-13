using UnityEngine;
using TMPro;
using ChickenVSZombies.Characters.Chicken.Mechanics;

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
            ChickenShooting.OnWeaponShot += UpdateBulletsLeftText;
        }

        private void OnDisable()
        {
            ChickenShooting.OnWeaponShot += UpdateBulletsLeftText;
        }

        private void UpdateBulletsLeftText()
        {
            _showBulletsLeftText.text = "Bullets Left: " + _chickenShooting.ChickenInventory.EquippedWeapon.Magazine.BulletsInMagazine;
        }
    }
}