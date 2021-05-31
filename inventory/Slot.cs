using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   public GameObject item;

    public GameObject Player;

    [HideInInspector]
    public int BonusDamage;
    [HideInInspector]
    public float duration;
    [HideInInspector]
    public int healhing;
   public int id;
   public string type;
   public string description;
   public bool empty;
   public Sprite icon;

   public Transform SlotIcon;

    private Button button;

   private void Start() {
    empty = true;
    SlotIcon = transform.GetChild(0);    
   }

    public void updateSlot(){
        SlotIcon.GetComponent<Image>().sprite = icon;
    }
    public void effect(){
        playerMove player = Player.GetComponent<playerMove>();
        Debug.Log(player.JumpForce);
        player.damageBonus(BonusDamage,duration,healhing);
    }

}
