using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

    GameObject textMoney = GameObject.Find("Money");
    
    float money = 0;
    void Update(){
        textMoney.text = "a";
    }
}
