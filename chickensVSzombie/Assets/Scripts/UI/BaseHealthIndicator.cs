using UnityEngine;
using TMPro;
using ChickenVSZombies.Base;

namespace ChickenVSZombies.UI 
{
    public class BaseHealthIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showBaseHealthText;

        private BaseHealth _baseHealth;

        private void Awake()
        {
            _baseHealth = FindObjectOfType<BaseHealth>();
        }

        private void OnEnable()
        {
            BaseHealth.OnBaseHealthChanged += UpdateBaseHealthText;
        }

        private void OnDisable()
        {
            BaseHealth.OnBaseHealthChanged -= UpdateBaseHealthText;
        }

        private void UpdateBaseHealthText()
        {
            _showBaseHealthText.text = "Base Health: " + _baseHealth.BaseLife;
        }
    }
}