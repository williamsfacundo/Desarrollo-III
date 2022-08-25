using System.Collections.Generic;
using ChickenVSZombies.Characters.Chicken.Interfaces;
using ChickenVSZombies.Characters.Chicken.Weapons.Firearms;

namespace ChickenVSZombies.Characters.Chicken
{
    public class ChickenInventory
    {
        //private const short inventoryInitialSize = 2; Para cuando el inventario tenga mas de un objeto

        private List<IEquippableItem> _items;

        public List<IEquippableItem> Items
        {
            get
            {
                return _items;
            }
        }

        public ChickenInventory()
        {
            _items = new List<IEquippableItem>();

            _items.Add(new Rifle()); //Por ahora el jugador solo contara con un rifle en el inventario
        }
    }
}
