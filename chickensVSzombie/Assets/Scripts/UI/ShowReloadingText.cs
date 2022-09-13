using UnityEngine;
using TMPro;
using ChickenVSZombies.Characters.Chicken.Mechanics;

namespace ChickenVSZombies.UI 
{
    public class ShowReloadingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _reloadingText;

        private const string _reloadingMeassege = "(RELOADING)";

        void OnEnable()
        {
            ChickenReloading.OnChickenStartReloading += ShowReloadingMeassege;

            ChickenReloading.OnChickenFinishedReloading += HideReloadingMeassege;
        }

        void OnDisable()
        {
            ChickenReloading.OnChickenStartReloading -= ShowReloadingMeassege;

            ChickenReloading.OnChickenFinishedReloading -= HideReloadingMeassege;
        }

        void ShowReloadingMeassege() 
        {
            _reloadingText.text = _reloadingMeassege;
        }

        void HideReloadingMeassege()
        {
            _reloadingText.text = " ";
        }
    }
}