using System.Collections.Generic;
using InventoryScripts;
using PlayerScripts;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        public GameObject inventoryPanel;
        public PlayerMovements player;
        public List<Slot_UI> slots = new List<Slot_UI>();
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            { ToggleInventory(); }
        }

        private void ToggleInventory()
        {
            if (!inventoryPanel.activeSelf)
            { inventoryPanel.SetActive(true);
                Setup();
            }
            else
            {
                inventoryPanel.SetActive(false);
            }

        }
        void Setup()
        {
            if (slots.Count == player.inventory.slots.Count)
            {
                for (int i = 0; i < slots.Count; i++)
                {
                    if (player.inventory.slots[i].type != CollectableType.NONE)
                    {
                        slots[i].SetItem(player.inventory.slots[i]);
                    }
                    else
                    {
                        slots[i].SetEmpty();
                    }
                }
            }
 
        }
    }
}
