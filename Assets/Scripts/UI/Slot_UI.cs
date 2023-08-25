using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

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
    void Update()
    public void SetEmpty()
    {

        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }
}
