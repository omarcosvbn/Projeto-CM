using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class WonkasFactory : MonoBehaviour{

    // DEFINE LIST WITH UPGRADES
    Upgrade[] _Upgrades = new Upgrade[]{
        new Upgrade {Name = "More cacao pods", Description = "You invest in transportation to get more cacao pods to your factory.", Boost= "Chocolate production + 50%", Order = 1, Cost= 50, Increase = 50},
        new Upgrade {Name = "Bigger roasters", Description = "More chocolate can be roasted simultaneously.", Boost= "Chocolate production + 50%", Order = 2, Cost= 50, Increase = 50},
        new Upgrade {Name = "Chocolate Tempering Machine", Description = "Install advanced machines for faster and more precise chocolate tempering, resulting in better quality chocolate", Boost= "Chocolate production + 50%", Order = 3, Cost= 50, Increase = 50},
        new Upgrade {Name = "Extra Sugar", Description = "People became more addicted to your chocolate", Boost= "Sales +100%", Order = 4, Cost= 150, Increase = 100 },
        new Upgrade {Name = "Oompa Loompas", Description = "You take a trip to Loompaland and invite its inhabitants to work at your factory in exchange for cocoa beans.", Boost= "Automate production", Order = 5, Cost= 50, Increase = 0},
        new Upgrade {Name = "Chocolate Tasting Room", Description = "Create a luxurious tasting room where visitors can sample a variety of chocolate creations.", Boost= "Sales +50%", Order = 6, Cost= 50, Increase = 50},

        new Upgrade {Name = "Bubblegum", Description = "You want create more than just chocolate. How about bubblegum?", Boost= "New factory sector", Order = 7, Cost= 50, Increase = 0},
        new Upgrade {Name = "New flavor - Breakfast", Description = "You have had a ground-breaking idea. A meal flavored Bubblegum.", Boost= "Bubblegum production +33.33%", Order = 8, Cost= 50, Increase = 33},
        new Upgrade {Name = "New flavor - Lunch", Description = "Take your previous idea to the next level by creating another meal based flavor.", Boost= "Bubblegum production +33.33%", Order = 9, Cost= 50, Increase = 33},
        new Upgrade {Name = "New flavor - Dinner", Description = "Since you have created breakfast and lunch flavored gum, might as well finish it off with a dinner flavored one", Boost= "Bubblegum production +33.33%", Order = 10, Cost= 50, Increase = 33},
        new Upgrade {Name = "3-Course's Dinner Gum", Description = "A final, more sophisticated version of the dinner flavor. WARNING: unexpected side effects may occur upon consumption", Boost= "Bubblegum production +100%", Order = 11, Cost= 50, Increase = 100},

        new Upgrade {Name = "Oompa Loompa Wellness program", Description = "Implement a wellness program to ensure the health and happiness of your workers", Boost= "Less energy drained from Ommpa Loompa", Order = 12, Cost= 50, Increase = 0},
        new Upgrade {Name = "Oompa Loompa Eficiency Training", Description = "Boost production speed with better-trained Oompa Loompas", Boost= "Production Speed +100", Order = 13, Cost= 50, Increase = 100},
        new Upgrade {Name = "Oompa Loompa Retirement plan", Description = "Implement a retirement plan for aging Oompa Loompas to boost morale", Boost= "Production Speed +100", Order = 14, Cost= 50, Increase = 100}
    };

    [SerializeField] private Button Upgrade_button1;
    [SerializeField] private Button Upgrade_button2;
    [SerializeField] private Button Upgrade_button3;
    [SerializeField] private Button Upgrade_button4;

    [SerializeField] private Text Upgrade_DescriptionText1;
    [SerializeField] private Text Upgrade_DescriptionText2;
    [SerializeField] private Text Upgrade_DescriptionText3;
    [SerializeField] private Text Upgrade_DescriptionText4;

    [SerializeField] private Image moneyBar;
    [SerializeField] public Text moneyText;
    [SerializeField] private Image stockBar;
    [SerializeField] private Text stockText;
    [SerializeField] private Text Oompas;

    private double money;
    private float upgrades;
    private int stock;
    private float stockToUpdate;
    private int maxStock;
    private int oompaQuantity;
    private float oompaGrade;


    public void Start(){
        upgrades = 1;
        stock = 0;
        maxStock = 10;
        oompaGrade = 0.5f;

        ButtonsSet();
    }
    
    public void Update(){
        moneyText.text = "Money: " + money.ToString("F2");

        if(stock < maxStock) stockToUpdate += 2.9f * Time.deltaTime;
        if(stock > maxStock) stock = maxStock;
        stockText.text = stock + "/" + maxStock;

        if(moneyBar.fillAmount < 1){
            moneyBar.fillAmount += 0.2f * Time.deltaTime;
        }
        else if(moneyBar.fillAmount >= 1){
            //ajustar valores de upgrade aqui
            money += upgrades * stock + oompaQuantity * oompaGrade;
            stock = 0;
            moneyBar.fillAmount = 0;
        }

        if(stockBar.fillAmount < 1 && stock < maxStock){
            stockBar.fillAmount += 0.8f * Time.deltaTime;
        }
        else if(stockBar.fillAmount >= 1){
            stock += (int)Mathf.Round(stockToUpdate);
            stockToUpdate = 0;
            stockBar.fillAmount = 0;
        }
        
        Oompas.text = "Oompa-Loompas: " + oompaQuantity.ToString();
    }

    public void ButtonsSet(){
        // CHOOSING UPGRADE FROM UPGRADE ARRAY
        List<int> availableUpgrades = new List<int>();
        for (int i = 0; i < _Upgrades.Length; i++){
            availableUpgrades.Add(i);
        }

        Upgrade Upgrade_1 = _Upgrades[availableUpgrades[0]];
        Upgrade Upgrade_2 = _Upgrades[availableUpgrades[1]];
        Upgrade Upgrade_3 = _Upgrades[availableUpgrades[2]];
        Upgrade Upgrade_4 = _Upgrades[availableUpgrades[3]];

        // Setting text
        Upgrade_button1.transform.GetChild(0).GetComponent<Text>().text = Upgrade_1.Name;
        Upgrade_button2.transform.GetChild(0).GetComponent<Text>().text = Upgrade_2.Name;
        Upgrade_button3.transform.GetChild(0).GetComponent<Text>().text = Upgrade_3.Name;
        Upgrade_button4.transform.GetChild(0).GetComponent<Text>().text = Upgrade_4.Name;


        // Replacing the X with increase value
        Upgrade_DescriptionText1.text = Upgrade_1.Name;
        Upgrade_DescriptionText2.text = Upgrade_2.Name;
        Upgrade_DescriptionText3.text = Upgrade_3.Name;
        Upgrade_DescriptionText4.text = Upgrade_4.Name;
    }

    public void RemoveUpgrade(string upgradeName){
        // Find the index of the upgrade with the given name
        int indexToRemove = -1;
        for (int i = 0; i < _Upgrades.Length; i++){
            if (_Upgrades[i].Name == upgradeName)
            {
                indexToRemove = i;
                break;
            }
        }

        // If the upgrade with the given name was found, remove it
        if (indexToRemove != -1){
            List<Upgrade> upgradesList = new List<Upgrade>(_Upgrades);
            upgradesList.RemoveAt(indexToRemove);
            _Upgrades = upgradesList.ToArray();
        }

        ButtonsSet();
    }

     // UPGRADES
    public void UpgradeChosen(string upgradeChosen){
        if (upgradeChosen == "More cacao pods"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                RemoveUpgrade("More cacao pods");
            }
            Debug.Log("More cacao pods");
        }
        else if (upgradeChosen == "Bigger roasters"){
            Debug.Log("Bigger roasters");
        }
        else if (upgradeChosen == "Chocolate Tempering Machine"){
            Debug.Log("Chocolate Tempering Machine");
        }
        else if (upgradeChosen == "Extra Sugar"){
            Debug.Log("Extra Sugar");
        }
        else if (upgradeChosen == "Oompa Loompas"){
            Debug.Log("Oompa Loompas");
        }
        else if (upgradeChosen == "Chocolate Tasting Room"){
            Debug.Log("Chocolate Tasting Room");
        }
        else if (upgradeChosen == "Bubblegum"){
            Debug.Log("Bubblegum");
        }
        else if (upgradeChosen == "New flavor - Breakfast"){
            Debug.Log("New flavor - Breakfast");
        }
        else if (upgradeChosen == "New flavor - Lunch"){
            Debug.Log("New flavor - Lunch");
        }
        else if (upgradeChosen == "New flavor - Dinner"){
            Debug.Log("New flavor - Dinner");
        }
        else if (upgradeChosen == "3-Course's Dinner Gum"){
            Debug.Log("3-Course's Dinner Gum");
        }
        else if (upgradeChosen == "Oompa Loompa Wellness program"){
            Debug.Log("Oompa Loompa Wellness program");
        }
        else if (upgradeChosen == "Oompa Loompa Eficiency Training"){
            Debug.Log("Oompa Loompa Eficiency Training");
        }
        else if (upgradeChosen == "Oompa Loompa Retirement plan"){
            Debug.Log("Oompa Loompa Retirement plan");
        }
    }

    public void OompaBuy(){
        oompaQuantity += 1;
    }

    public class Upgrade{
        public string Name { get; set; }
        public string Description { get; set; }
        public string Boost { get; set; }
        public double Cost { get; set; }
        public int Order { get; set; }
        public float Increase { get; set; }
    }
}
