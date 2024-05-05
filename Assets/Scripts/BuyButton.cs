using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BuyButton : MonoBehaviour, IPointerDownHandler{

    [SerializeField] private WonkasFactory upgradesScript;
    [SerializeField] private GameObject button;
    [SerializeField] private Text chocStockText;
    [SerializeField] private Text gumStockText;
    [SerializeField] private Text gobStockText;

    public void OnPointerDown(PointerEventData eventData){
        if(button.name == "Chocolate"){
            upgradesScript.chocStock += 1;
            chocStockText.text = upgradesScript.chocStock.ToString();
        }
        if(button.name == "Gum"){
            upgradesScript.gumStock += 1;
            gumStockText.text = upgradesScript.gumStock.ToString();
        }
        if(button.name == "Gobstopper"){
            upgradesScript.gobStock += 1;
            gobStockText.text = upgradesScript.gobStock.ToString();
        }
    }
}
