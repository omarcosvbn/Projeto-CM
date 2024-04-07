using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Security.Cryptography.X509Certificates;


public class NewBehaviourScript : MonoBehaviour{

    public TextMeshProUGUI textMoney;
    public Image upgrade1;

    
    float money = 0f;
    float moneyPerSecond = 1f;
    float upgrades = 1f;
    void Update(){
        money += (moneyPerSecond * upgrades) * Time.deltaTime;
        textMoney.text = money.ToString("F2");
    }
}