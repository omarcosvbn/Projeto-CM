using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    [SerializeField] private WonkasFactory upgradesScript;
    [SerializeField] private Text upgradeDescriptionText;
    public bool isOn;

    public void Upgrade(){
        string upgradeChosen = upgradeDescriptionText.text;
        upgradesScript.UpgradeChosen(upgradeChosen);
    }

    public void OnPointerEnter(PointerEventData eventData){
        isOn = true;  
    }

    public void OnPointerExit(PointerEventData eventData){
        isOn = false;  
    }
}
