using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WonkasFactory : MonoBehaviour{

    public Text moneyText;
    public double money;
    public float upgrades;

    public void Start(){
        money = 0;
        upgrades = 1;
    }
    
    public void Update(){
        money += 1 * upgrades * Time.deltaTime;
        moneyText.text = "Money: " + money.ToString("F2");
    }

    public void Upgrade(){
        upgrades *= 1.5f;
    }
}
