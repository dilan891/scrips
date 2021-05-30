using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyScript : MonoBehaviour
{
    private int cash;
    public int initialCash;

    private void Start() {
        cash = initialCash;
    }

    public void incrementCash(int increment){
            cash += increment; 
    }

    public void viewCash(){
        Debug.Log(cash);
    }

    public bool decrementCash(int decremet){
        if((cash - decremet) < 0){
            return false;
        }
        else{
            cash -= decremet;
            return true;
        }
        
    }
}
