using System.Collections;
using System.Collections.Generic;
using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    /*Set icon and quantity*/
    public void SetItem(Inventory.Slot slot)
    {

        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    // Update is called once per frame
    public void SetEmpty()
    {

            itemIcon.sprite = null;
            /*make the image invisible */
            itemIcon.color = new Color(1, 1, 1, 0);
            quantityText.text = "";
    }
}
