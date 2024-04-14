using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour{
    [SerializeField] private WonkasFactory upgradesScript;
    [SerializeField] private Text upgradeDescriptionText;

    public void Upgrade(){
        string upgradeChosen = upgradeDescriptionText.text;
        upgradesScript.UpgradeChosen(upgradeChosen);
        //upgradesScript.ButtonsSet();
    }
}
