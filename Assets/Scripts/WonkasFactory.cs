using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WonkasFactory : MonoBehaviour{

    public Text moneyText;
    public double money;

    public void Start(){
        money = 0;

    }
    
    public void Update(){
        money += 1 * Time.deltaTime;
        moneyText.text = "Money: " + money.ToString("F2");
    }

    //public void Upgrade
}
