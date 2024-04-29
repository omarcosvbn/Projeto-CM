using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour{
    [SerializeField] private WonkasFactory upgradesScript;
    [SerializeField] private Text upgradeDescriptionText;
    public bool isOn;

    public void Upgrade(){
        string upgradeChosen = upgradeDescriptionText.text;
        upgradesScript.UpgradeChosen(upgradeChosen);
    }

    public void OnMouseOver(){
        isOn = true;
    }

    public void OnMouseExit(){
        isOn = false;
    }
    
    void Update(){
        if(isOn == true)Debug.Log("Mouse is over GameObject.");
        else Debug.Log("Mouse is no longer on GameObject.");
    }
}
