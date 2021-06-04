using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    
    private bool inventoryEnable;

    private int allslots;

    private int eneableslot;

    private GameObject[] slots;

    public GameObject SlotHolder;

    public GameObject Inventory;

    void Start()
    {
        allslots = SlotHolder.transform.childCount;

        slots =  new GameObject[allslots];

        for (int i = 0; i < allslots; i++)
        {   
            slots[i] = SlotHolder.transform.GetChild(i).gameObject;

            if(slots[i].GetComponent<Slot>().item == null){
                slots[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryEnable = !inventoryEnable;
        }

        if(inventoryEnable){
            Inventory.SetActive(true);
        }
        else Inventory.SetActive(false);

    }

private void  OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="Item"){
        
        GameObject itemPickup  = other.gameObject;

        ItemInventory item = itemPickup.GetComponent<ItemInventory>();

        item ItemBonus = itemPickup.GetComponent<item>();

        Additem(itemPickup,item.id,item.type,item.description,item.icon,ItemBonus.BonusDamage,ItemBonus.duration,ItemBonus.Healhing);
    
        //Destroy(itemPickup);
    }
}

public void Additem (GameObject itemObject,int ItemID,string ItemType,string ItemDescription,Sprite ItemIcon,int damage,float duration,int health){
    for (int i = 0; i < allslots; i++)
    {
        if(slots[i].GetComponent<Slot>().empty){
            itemObject.GetComponent<ItemInventory>().pickeUp = true;

            slots[i].GetComponent<Slot>().item = itemObject;
            slots[i].GetComponent<Slot>().id = ItemID;
            slots[i].GetComponent<Slot>().type = ItemType;
            slots[i].GetComponent<Slot>().description = ItemDescription;
            slots[i].GetComponent<Slot>().icon = ItemIcon;
            slots[i].GetComponent<Slot>().BonusDamage = damage;
            slots[i].GetComponent<Slot>().duration = duration;
            slots[i].GetComponent<Slot>().healhing = health;

            itemObject.transform.parent = slots[i].transform;
            
            itemObject.SetActive(false);

            slots[i].GetComponent<Slot>().updateSlot();

            slots[i].GetComponent<Slot>().empty = false;
            break;
        }   
    }
}

}
