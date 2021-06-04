using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private int Id;
    public int BonusDamage;
    public float duration;
    public int Healhing;

    /*private void OnTriggerEnter2D(Collider2D other) {
        playerMove player = other.GetComponent<playerMove>();
        moneyScript money = other.GetComponent<moneyScript>();
        if(player != null){
            player.damageBonus(BonusDamage,duration,healhing);
            Destroy(gameObject);
        }
    }*/

    /*public void AppliEffect(int id,int BonusDamage,int healthing,float duration){
        Id = id;
        this.BonusDamage = BonusDamage;
        this.duration  = duration;
        this.Healhing = healthing;

        playerMove player = GetComponent<playerMove>();
        player.damageBonus(this.BonusDamage,this.duration,this.Healhing);
    }
*/
}
