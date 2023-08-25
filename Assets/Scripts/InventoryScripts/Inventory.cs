using System.Collections.Generic;
using UnityEngine;

namespace InventoryScripts
{
    [System.Serializable]
// no mono we're not gonna add inventory script of the game objects.
    public class Inventory
    {
        [System.Serializable]
        //what items - how many of that item - the number of item allowed in the slot
        public class Slot
        {
            public CollectableType type;
            public int count; /*How many items in the slot*/
            public int maxAllowed;
            public Sprite icon;
            public Slot()
            {
                type = CollectableType.NONE;
                count = 0;
                maxAllowed = 10;
            }
            public bool CanAddItem()
            {
                if (count < maxAllowed)
                {
                    return true;
                }
                return false;
            }
            public void AddItem(Collectable item)
            {
                this.type = item.type;
                this.icon = item.icon;
                count++;
            }
        }

        public List<Slot> slots = new List<Slot>();

        //constructor
        public Inventory(int numSlots)
        {
            for(int i = 0; i < numSlots; i++)
            {
                Slot slot= new Slot();
                slots.Add(slot);
            }
        }

        //Maybe do serialize
        public void Add(Collectable item)
        {
            CollectableType col = new CollectableType();
            foreach(Slot slot in slots)
            {
                if (slot.type == item.type && slot.CanAddItem()) 
                {
                    slot.AddItem(item);
                    return;
                }
            }
            foreach(Slot slot in slots)
            {
                if (slot.type == CollectableType.NONE)
                {
                    slot.AddItem(item);
                    return;
                }
            }
            
        }
    }
}
