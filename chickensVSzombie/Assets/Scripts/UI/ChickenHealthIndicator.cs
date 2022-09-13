using UnityEngine;
using TMPro;
using ChickenVSZombies.Characters.Chicken;

namespace ChickenVSZombies.UI 
{
    public class ChickenHealthIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showChickenHealthText;

        private ChickenHealth _chickenHealth;

        private void Awake()
        {
            _chickenHealth = FindObjectOfType<ChickenHealth>();
        }

        private void OnEnable()
        {
            ChickenHealth.OnHealthChanged += UpdateChickenHealthText;
        }

        private void OnDisable()
        {
            ChickenHealth.OnHealthChanged += UpdateChickenHealthText;
        }        

        private void UpdateChickenHealthText() 
        {
            _showChickenHealthText.text = "Chicken Health: " + _chickenHealth.Life;
        }
    }
}