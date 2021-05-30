using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int BonusDamage;
    public float duration;
    public int healhing;
    private void OnTriggerEnter2D(Collider2D other) {
        playerMove player = other.GetComponent<playerMove>();
        moneyScript money = other.GetComponent<moneyScript>();
        if(player != null){
            player.damageBonus(BonusDamage,duration,healhing);
            Destroy(gameObject);
        }
    }

}
