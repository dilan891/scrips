using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    public float barSpeed = 1f;

    public Image healthbar;

    private float nextHealth;

    private void Awake() {
        healthbar.fillAmount = 1f;
        nextHealth = healthbar.fillAmount;
    }

    private void Update() {
        if(healthbar.fillAmount != nextHealth){
            healthbar.fillAmount = Mathf.MoveTowards(healthbar.fillAmount,nextHealth,Time.deltaTime * barSpeed);
        }
    }

    public void SetHealth(float healthPorcentaje){
        nextHealth = healthPorcentaje;
    }

}
