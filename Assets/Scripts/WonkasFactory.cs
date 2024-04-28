using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class WonkasFactory : MonoBehaviour{

    // DEFINE LIST WITH UPGRADES
    Upgrade[] _Upgrades = new Upgrade[]{
        //Chocolate upgrades
        new Upgrade {Name = "More cacao pods", Description = "You invest in transportation to get more cacao pods to your factory.", Boost= "Chocolate production + 50%", Order = 1, Cost= 50, Increase = 50},
        new Upgrade {Name = "Bigger roasters", Description = "More chocolate can be roasted simultaneously.", Boost= "Chocolate production + 50%", Order = 2, Cost= 50, Increase = 50},
        new Upgrade {Name = "Chocolate Tempering Machine", Description = "Install advanced machines for faster and more precise chocolate tempering, resulting in better quality chocolate", Boost= "Chocolate production + 50%", Order = 3, Cost= 50, Increase = 50},
        new Upgrade {Name = "Extra Sugar", Description = "People became more addicted to your chocolate", Boost= "Sales +100%", Order = 4, Cost= 150, Increase = 100 },
        new Upgrade {Name = "Oompa Loompas", Description = "You take a trip to Loompaland and invite its inhabitants to work at your factory in exchange for cocoa beans.", Boost= "Automate production", Order = 5, Cost= 50, Increase = 0},
        new Upgrade {Name = "Chocolate Tasting Room", Description = "Create a luxurious tasting room where visitors can sample a variety of chocolate creations.", Boost= "Sales +50%", Order = 6, Cost= 50, Increase = 50},
       
        //Bubblegum upgrades
        new Upgrade {Name = "Bubblegum", Description = "You want create more than just chocolate. How about bubblegum?", Boost= "New factory sector", Order = 7, Cost= 50, Increase = 0},
        new Upgrade {Name = "New flavor - Breakfast", Description = "You have had a ground-breaking idea. A meal flavored Bubblegum.", Boost= "Bubblegum production +33.33%", Order = 8, Cost= 50, Increase = 33},
        new Upgrade {Name = "New flavor - Lunch", Description = "Take your previous idea to the next level by creating another meal based flavor.", Boost= "Bubblegum production +33.33%", Order = 9, Cost= 50, Increase = 33},
        new Upgrade {Name = "New flavor - Dinner", Description = "Since you have created breakfast and lunch flavored gum, might as well finish it off with a dinner flavored one", Boost= "Bubblegum production +33.33%", Order = 10, Cost= 50, Increase = 33},
        new Upgrade {Name = "3-Course's Dinner Gum", Description = "A final, more sophisticated version of the dinner flavor. WARNING: unexpected side effects may occur upon consumption", Boost= "Bubblegum production +100%", Order = 11, Cost= 50, Increase = 100},
        
        //Gobstopper upgrades
        new Upgrade {Name = "Gobstoppers", Description = "You need more variety of sweets to appeal to more people. How about something that lasts in your mouth but you do not need to chew?", Boost= "New factory sector", Order = 12, Cost= 50, Increase = 0},
        new Upgrade {Name = "New flavors", Description = "You create new flavors of Godstoppers", Boost= "Sales +100%", Order = 13, Cost= 50, Increase = 33},
        new Upgrade {Name = "A variety of flavors, One Gobstopper", Description = "What if you combine all of the flavors created into one single gobstopper?", Boost= "Sales 1000%", Order = 14, Cost= 50, Increase = 33},
        new Upgrade {Name = "New recipe - Longer lasting", Description = "People like your Gobstoppers so much they are asking for longer lasting ones! Create a new recipe for them to last longer.", Boost= "Gobstoppers production +50%", Order = 15, Cost= 50, Increase = 33},
        new Upgrade {Name = "Experimenting phase", Description = "Before you reveal your new product, you must test it to see if it holds up to the expectations. Build a machine to shoo them into a pool of water to test how long they last.", Boost= "Gobstoppers production +50%", Order = 16, Cost= 50, Increase = 100},
        new Upgrade {Name = "24h Gobstoppers!", Description = "Your Gobstoppers surpass expectations! Each one lasts a total of 24h in water. Is it possible to create a Gobstopper that lasts forever?", Boost= "Sales +100%", Order = 17, Cost= 50, Increase = 100},
        new Upgrade {Name = "Everlasting Gobstoppers", Description = "These new Gobstoppers are meant for children who are given very little allowance money. You can suck on them all year and they will never get any smaller.", Boost= "Sales +100%", Order = 18, Cost= 50, Increase = 100},


        //Oompa Loompa upgrades
        new Upgrade {Name = "Oompa Loompa Wellness program", Description = "Implement a wellness program to ensure the health and happiness of your workers", Boost= "Less energy drained from Ommpa Loompa", Order = 19, Cost= 50, Increase = 0},
        new Upgrade {Name = "Oompa Loompa Eficiency Training", Description = "Boost production speed with better-trained Oompa Loompas", Boost= "Production Speed +100", Order = 20, Cost= 50, Increase = 100},
        new Upgrade {Name = "Oompa Loompa Retirement plan", Description = "Implement a retirement plan for aging Oompa Loompas to boost morale", Boost= "Production Speed +100", Order = 21, Cost= 50, Increase = 100},
        
        
        
        new Upgrade {Name = "", Description = "", Boost= "", Order = 100, Cost= 0, Increase = 0}
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
    [SerializeField] private Text chocStockText;
    [SerializeField] private Text gumStockText;
    [SerializeField] private Text gobStockText;
    [SerializeField] private Text Oompas;

    [SerializeField] private AudioSource upgradeSound;

    [SerializeField] private Image rightFactory;
    [SerializeField] private Image leftFactory;
    [SerializeField] private Image topFactory;

    private double money;
    private float upgrades;
    private int chocStock;
    private int gumStock;
    private int gobStock;
    private int oompaQuantity;
    private float oompaGrade;

    private float chocStockTimer = 0f;
    private float chocStockUpdateInterval = 5f; // Update stock every x seconds

    private float gumStockTimer = 0f;
    private float gumStockUpdateInterval = 5f; // Update stock every x seconds

    private float gobStockTimer = 0f;
    private float gobStockUpdateInterval = 5f; // Update stock every x seconds


    public void Start(){
        upgrades = 1;
        chocStock = 0;
        gumStock = 0;
        gobStock = 0;
        oompaGrade = 0.5f;
        rightFactory.enabled = false;
        leftFactory.enabled = false;
        topFactory.enabled = false;
        ButtonsSet();
    }
    
    public void Update(){
        moneyText.text = "Money: " + money.ToString("F2");

        chocStockTimer += Time.deltaTime;
        if (chocStockTimer >= chocStockUpdateInterval) {
            chocStock += 1;
            chocStockText.text = chocStock.ToString();
            chocStockTimer = 0f;
        }

        gumStockTimer += Time.deltaTime;
        if (gumStockTimer >= gumStockUpdateInterval) {
            gumStock += 1;
            gumStockText.text = gumStock.ToString();
            gumStockTimer = 0f;
        }

        gobStockTimer += Time.deltaTime;
        if (gobStockTimer >= gobStockUpdateInterval) {
            gobStock += 1;
            gobStockText.text = gobStock.ToString();
            gobStockTimer = 0f;
        }

        if(moneyBar.fillAmount < 1){
            moneyBar.fillAmount += 0.02f * Time.deltaTime;
        }
        else if(moneyBar.fillAmount >= 1){
            //ajustar valores de upgrade aqui
            money += upgrades * chocStock + upgrades * gumStock + upgrades * gobStock + oompaQuantity * oompaGrade;
            chocStock = 0;
            gumStock = 0;
            gobStock = 0;
            moneyBar.fillAmount = 0;
        }
        
        Oompas.text = "Oompa-Loompas: " + oompaQuantity.ToString();
    }

    public void ButtonsSet(){
        // CHOOSING UPGRADE FROM UPGRADE ARRAY
        List<int> availableUpgrades = new List<int>();
        for (int i = 0; i < _Upgrades.Length; i++){
            availableUpgrades.Add(i);
        }

        Upgrade Upgrade_1 = availableUpgrades.Count > 0 ? _Upgrades[availableUpgrades[0]] : _Upgrades[availableUpgrades.Count - 1];
        Upgrade Upgrade_2 = availableUpgrades.Count > 1 ? _Upgrades[availableUpgrades[1]] : _Upgrades[availableUpgrades.Count - 1];
        Upgrade Upgrade_3 = availableUpgrades.Count > 2 ? _Upgrades[availableUpgrades[2]] : _Upgrades[availableUpgrades.Count - 1];
        Upgrade Upgrade_4 = availableUpgrades.Count > 3 ? _Upgrades[availableUpgrades[3]] : _Upgrades[availableUpgrades.Count - 1];

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
                upgradeSound.Play();
                RemoveUpgrade("More cacao pods");
            }
            Debug.Log("More cacao pods");
        }
        else if (upgradeChosen == "Bigger roasters"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Bigger roasters");
            }
            Debug.Log("Bigger roasters");
        }
        else if (upgradeChosen == "Chocolate Tempering Machine"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Chocolate Tempering Machine");
            }
            Debug.Log("Chocolate Tempering Machine");
        }
        else if (upgradeChosen == "Extra Sugar"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Extra Sugar");
            }
            Debug.Log("Extra Sugar");
        }
        else if (upgradeChosen == "Oompa Loompas"){
            RemoveUpgrade("Oompa Loompas");
            Debug.Log("Oompa Loompas");
        }
        else if (upgradeChosen == "Chocolate Tasting Room"){
            RemoveUpgrade("Chocolate Tasting Room");
            Debug.Log("Chocolate Tasting Room");
        }
        else if (upgradeChosen == "Bubblegum"){
            rightFactory.enabled = true;
            RemoveUpgrade("Bubblegum");
            Debug.Log("Bubblegum");
        }
        else if (upgradeChosen == "New flavor - Breakfast"){
            RemoveUpgrade("New flavor - Breakfast");
            Debug.Log("New flavor - Breakfast");
        }
        else if (upgradeChosen == "New flavor - Lunch"){
            RemoveUpgrade("New flavor - Lunch");
            Debug.Log("New flavor - Lunch");
        }
        else if (upgradeChosen == "New flavor - Dinner"){
            RemoveUpgrade("New flavor - Dinner");
            Debug.Log("New flavor - Dinner");
        }
        else if (upgradeChosen == "3-Course's Dinner Gum"){
            RemoveUpgrade("3-Course's Dinner Gum");
            Debug.Log("3-Course's Dinner Gum");
        }
        else if (upgradeChosen == "Gobstoppers"){
            leftFactory.enabled = true;
            RemoveUpgrade("Gobstoppers");
            Debug.Log("Gobstoppers");
        }
        else if (upgradeChosen == "New flavors"){
            RemoveUpgrade("New flavors");
            Debug.Log("New flavors");
        }
        else if (upgradeChosen == "A variety of flavors, One Gobstopper"){
            RemoveUpgrade("A variety of flavors, One Gobstopper");
            Debug.Log("A variety of flavors, One Gobstopper");
        }
        else if (upgradeChosen == "New recipe - Longer lasting"){
            RemoveUpgrade("New recipe - Longer lasting");
            Debug.Log("New recipe - Longer lasting");
        }
        else if (upgradeChosen == "Experimenting phase"){
            RemoveUpgrade("Experimenting phase");
            Debug.Log("Experimenting phase");
        } 
        else if (upgradeChosen == "24h Gobstoppers!"){
            RemoveUpgrade("24h Gobstoppers!");
            Debug.Log("24h Gobstoppers!");
        }
        else if (upgradeChosen == "Everlasting Gobstoppers"){
            RemoveUpgrade("Everlasting Gobstoppers");
            Debug.Log("Everlasting Gobstoppers");
        }
        else if (upgradeChosen == "Oompa Loompa Wellness program"){
            RemoveUpgrade("Oompa Loompa Wellness program");
            Debug.Log("Oompa Loompa Wellness program");
        }
        else if (upgradeChosen == "Oompa Loompa Eficiency Training"){
            RemoveUpgrade("Oompa Loompa Eficiency Training");
            Debug.Log("Oompa Loompa Eficiency Training");
        }
        else if (upgradeChosen == "Oompa Loompa Retirement plan"){
            RemoveUpgrade("Oompa Loompa Retirement plan");
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
