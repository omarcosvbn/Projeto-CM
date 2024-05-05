using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class WonkasFactory : MonoBehaviour{

    // DEFINE LIST WITH UPGRADES
    Upgrade[] _Upgrades = new Upgrade[]{
        //Chocolate upgrades
        new Upgrade {Name = "More cacao pods", Description = "You invest in transportation to get more cacao pods to your factory.", Boost= "Chocolate production + 50%", Cost="1", Order = 1},
        new Upgrade {Name = "Bigger roasters", Description = "More chocolate can be roasted simultaneously.", Boost= "Chocolate production + 50%", Cost="1", Order = 2},
        new Upgrade {Name = "Chocolate Tempering Machine", Description = "Install advanced machines for faster and more precise chocolate tempering, resulting in better quality chocolate", Boost= "Chocolate production + 50%", Cost="1", Order = 3},
        new Upgrade {Name = "Extra Sugar", Description = "People became more addicted to your chocolate", Boost= "Sales +100%", Cost="1", Order = 4},
        new Upgrade {Name = "Oompa Loompas", Description = "You take a trip to Loompaland and invite its inhabitants to work at your factory in exchange for cocoa beans.", Boost= "Unlocks Oompa Loompas", Cost="1", Order = 5},
        new Upgrade {Name = "Chocolate Tasting Room", Description = "Create a luxurious tasting room where visitors can sample a variety of chocolate creations.", Boost= "Sales +50%", Cost="1", Order = 6},
       
        //Bubblegum upgrades
        new Upgrade {Name = "Bubblegum", Description = "You want create more than just chocolate. How about bubblegum?", Boost= "New factory sector", Cost="1", Order = 7},
        new Upgrade {Name = "New flavor - Breakfast", Description = "You have had a ground-breaking idea. A meal flavored Bubblegum.", Boost= "Bubblegum production +33.33%", Cost="1", Order = 8},
        new Upgrade {Name = "New flavor - Lunch", Description = "Take your previous idea to the next level by creating another meal based flavor.", Boost= "Bubblegum production +33.33%", Cost="1", Order = 9},
        new Upgrade {Name = "New flavor - Dinner", Description = "Since you have created breakfast and lunch flavored gum, might as well finish it off with a dinner flavored one", Boost= "Bubblegum production +33.33%", Cost="1", Order = 10},
        new Upgrade {Name = "OompaLoompa Housing", Description = "With a new place to rest, the Oompa Loompas become more productive", Boost= "New factory sector", Cost="1", Order = 11},
        new Upgrade {Name = "3-Course's Dinner Gum", Description = "A final, more sophisticated version of the dinner flavor. WARNING: unexpected side effects may occur upon consumption", Boost= "Bubblegum production +100%", Cost="1", Order = 12},
        
        //Gobstopper upgrades
        new Upgrade {Name = "Gobstoppers", Description = "You need more variety of sweets to appeal to more people. How about something that lasts in your mouth but you do not need to chew?", Boost= "New factory sector", Cost="1", Order = 13},
        new Upgrade {Name = "New flavors", Description = "You create new flavors of Godstoppers", Boost= "Sales +100%", Cost="1", Order = 14},
        new Upgrade {Name = "A variety of flavors, One Gobstopper", Description = "What if you combine all of the flavors created into one single gobstopper?", Boost= "Sales 1000%", Cost="1", Order = 15},
        new Upgrade {Name = "New recipe - Longer lasting", Description = "People like your Gobstoppers so much they are asking for longer lasting ones! Create a new recipe for them to last longer.", Boost= "Gobstoppers production +50%", Cost="1", Order = 16},
        new Upgrade {Name = "Experimenting phase", Description = "Before you reveal your new product, you must test it to see if it holds up to the expectations. Build a machine to shoot them into a pool of water to test how long they last.", Boost= "Gobstoppers production +50%", Cost="1", Order = 17},
        new Upgrade {Name = "24h Gobstoppers!", Description = "Your Gobstoppers surpass expectations! Each one lasts a total of 24h in water. Is it possible to create a Gobstopper that lasts forever?", Boost= "Sales +100%", Cost="1", Order = 18},
        new Upgrade {Name = "Everlasting Gobstoppers", Description = "These new Gobstoppers are meant for children who are given very little allowance money. You can suck on them all year and they will never get any smaller.", Boost= "Sales +100%", Cost="1", Order = 19},


        //Oompa Loompa upgrades
        new Upgrade {Name = "Oompa Loompa Wellness program", Description = "Implement a wellness program to ensure the health and happiness of your workers", Boost= "Less energy drained from Ommpa Loompa", Cost="1", Order = 20},
        new Upgrade {Name = "Oompa Loompa Eficiency Training", Description = "Boost production speed with better-trained Oompa Loompas", Boost= "Production Speed +100", Cost="1", Order = 21},
        new Upgrade {Name = "Oompa Loompa Retirement plan", Description = "Implement a retirement plan for aging Oompa Loompas to boost morale", Boost= "Production Speed +100", Cost="1", Order = 22},
        

        new Upgrade {Name = "", Description = "", Boost= "", Cost="", Order = 100}
    };

    [SerializeField] private Button Upgrade_button1;
    [SerializeField] private Button Upgrade_button2;
    [SerializeField] private Button Upgrade_button3;
    //[SerializeField] private Button Upgrade_button4;
   // [SerializeField] private Text Upgrade_DescriptionText1;
    //[SerializeField] private Text Upgrade_DescriptionText2;
    //[SerializeField] private Text Upgrade_DescriptionText3;
    //[SerializeField] private Text Upgrade_DescriptionText4;

    [SerializeField] private Text DescriptionText;

    [SerializeField] private Image moneyBar;
    [SerializeField] public Text moneyText;
    [SerializeField] private Text chocStockText;
    [SerializeField] private Text gumStockText;
    [SerializeField] private Text gobStockText;
    [SerializeField] private Text Oompas;

    [SerializeField] private AudioSource upgradeSound;
    [SerializeField] private AudioSource oompaVoice;

    [SerializeField] private Image rightFactory;
    [SerializeField] private Image leftFactory;
    [SerializeField] private Image topFactory;
    [SerializeField] private Image GumStock;
    [SerializeField] private Image GobstopperStock;


    //Imagens para os Oompa Loompas das janelas
    [SerializeField] private Image oompa1;
    [SerializeField] private Image oompa2;
    [SerializeField] private Image oompa3;
    [SerializeField] private Image oompa4;
    [SerializeField] private Image oompa5;
    [SerializeField] private Image oompa6;
    [SerializeField] private Image oompa7;
    [SerializeField] private Image oompa8;
    [SerializeField] private Image oompa9;
    [SerializeField] private Image oompa10;
    [SerializeField] private Image oompa11;
    [SerializeField] private Image oompa12;
    [SerializeField] private Image oompa13;
    [SerializeField] private Image oompa14;
    [SerializeField] private Image oompa15;
    [SerializeField] private Image oompa16;
    [SerializeField] private Image oompa17;
    [SerializeField] private Image oompa18;
    [SerializeField] private Image oompa19;
    [SerializeField] private Image oompa20;
    [SerializeField] private Image oompa21;
    [SerializeField] private Image oompa22;
    [SerializeField] private Image oompa23;
    [SerializeField] private Image oompa24;
    [SerializeField] private Image oompa25;
    [SerializeField] private Image oompa26;
    [SerializeField] private Image oompa27;
    [SerializeField] private Image oompa28;
    [SerializeField] private Image oompa29;


    [SerializeField] private GameObject oompaLoompa;

    [SerializeField] private Buttons button1;
    [SerializeField] private Buttons button2;
    [SerializeField] private Buttons button3;
   // [SerializeField] private Buttons button4;

    [SerializeField] private Text BoostText;
    [SerializeField] private Text CostText;


    private double money;
    private float stockSaleSpeed = 0.02f;
    private float upgrades;
    public int chocStock;
    public int gumStock;
    public int gobStock;
    private int oompaQuantity;
    private float oompaGrade;
    private bool gumAvailable;
    private bool gobAvailable;


    private float chocStockTimer = 0f;
    private float chocStockUpdateInterval = 5f; // Update stock every x seconds

    private float gumStockTimer = 0f;
    private float gumStockUpdateInterval = 5f; // Update stock every x seconds

    private float gobStockTimer = 0f;
    private float gobStockUpdateInterval = 5f; // Update stock every x seconds

    private float stockProductionSpeed = 1f;




    public void Start(){
        upgrades = 1;
        chocStock = 0;
        gumStock = 0;
        gobStock = 0;
        oompaGrade = 0.5f;
        money = 1000;
        rightFactory.enabled = false;
        leftFactory.enabled = false;
        topFactory.enabled = false;
        GumStock.enabled = false;
        GobstopperStock.enabled = false;

        oompa1.enabled = false;
        oompa2.enabled = false;
        oompa3.enabled = false;
        oompa4.enabled = false;
        oompa5.enabled = false;
        oompa6.enabled = false;
        oompa7.enabled = false;
        oompa8.enabled = false;
        oompa9.enabled = false;
        oompa10.enabled = false;
        oompa11.enabled = false;
        oompa12.enabled = false;
        oompa13.enabled = false;
        oompa14.enabled = false;
        oompa15.enabled = false;
        oompa16.enabled = false;
        oompa17.enabled = false;
        oompa18.enabled = false;
        oompa19.enabled = false;
        oompa20.enabled = false;
        oompa21.enabled = false;
        oompa22.enabled = false;
        oompa23.enabled = false;
        oompa24.enabled = false;
        oompa25.enabled = false;
        oompa26.enabled = false;
        oompa27.enabled = false;
        oompa28.enabled = false;
        oompa29.enabled = false;


        gumAvailable = false;
        gobAvailable = false;
        oompaLoompa.SetActive(false);
        ButtonsSet();
    }
    

    public void Update(){
        moneyText.text = "Money: " + money.ToString("F2");

        chocStockTimer += stockProductionSpeed * Time.deltaTime;
        if (chocStockTimer >= chocStockUpdateInterval) {
            chocStock += 1;
            chocStockText.text = chocStock.ToString();
            chocStockTimer = 0f;
        }

        gumStockTimer += stockProductionSpeed * Time.deltaTime;
        if (gumStockTimer >= gumStockUpdateInterval && gumAvailable == true) {
            gumStock += 1;
            gumStockText.text = gumStock.ToString();
            gumStockTimer = 0f;
        }

        gobStockTimer += stockProductionSpeed * Time.deltaTime;
        if (gobStockTimer >= gobStockUpdateInterval && gobAvailable == true) {
            gobStock += 1;
            gobStockText.text = gobStock.ToString();
            gobStockTimer = 0f;
        }

        if(moneyBar.fillAmount < 1){
            moneyBar.fillAmount += stockSaleSpeed * Time.deltaTime;
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


        // CHOOSING UPGRADE FROM UPGRADE ARRAY
        List<int> availableUpgrades = new List<int>();
        for (int i = 0; i < _Upgrades.Length; i++){
            availableUpgrades.Add(i);
        }

        Upgrade Upgrade_1 = availableUpgrades.Count > 0 ? _Upgrades[availableUpgrades[0]] : _Upgrades[availableUpgrades.Count - 1];
        Upgrade Upgrade_2 = availableUpgrades.Count > 1 ? _Upgrades[availableUpgrades[1]] : _Upgrades[availableUpgrades.Count - 1];
        Upgrade Upgrade_3 = availableUpgrades.Count > 2 ? _Upgrades[availableUpgrades[2]] : _Upgrades[availableUpgrades.Count - 1];
      //  Upgrade Upgrade_4 = availableUpgrades.Count > 3 ? _Upgrades[availableUpgrades[3]] : _Upgrades[availableUpgrades.Count - 1];

        if(button1.isOn == true) {
            DescriptionText.text = Upgrade_1.Description;
            BoostText.text = Upgrade_1.Boost;
            CostText.text = Upgrade_1.Cost;
        }else if(button2.isOn == true){
            DescriptionText.text = Upgrade_2.Description;
            BoostText.text = Upgrade_2.Boost;
            CostText.text = Upgrade_2.Cost;
        }else if(button3.isOn == true){
            DescriptionText.text = Upgrade_3.Description;
            BoostText.text = Upgrade_3.Boost;
            CostText.text = Upgrade_3.Cost;

        //}else if(button4.isOn == true){
           // DescriptionText.text = Upgrade_4.Description;
          //  BoostText.text = Upgrade_4.Boost;
        }else{
            DescriptionText.text = "";
            BoostText.text = "";
            CostText.text = "";
        }

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
        //Upgrade Upgrade_4 = availableUpgrades.Count > 3 ? _Upgrades[availableUpgrades[3]] : _Upgrades[availableUpgrades.Count - 1];

        // Setting text
        Upgrade_button1.transform.GetChild(0).GetComponent<Text>().text = Upgrade_1.Name;
        Upgrade_button2.transform.GetChild(0).GetComponent<Text>().text = Upgrade_2.Name;
        Upgrade_button3.transform.GetChild(0).GetComponent<Text>().text = Upgrade_3.Name;
        //Upgrade_button4.transform.GetChild(0).GetComponent<Text>().text = Upgrade_4.Name;


        // Replacing the X with increase value
        //Upgrade_DescriptionText1.text = Upgrade_1.Name;
        //Upgrade_DescriptionText2.text = Upgrade_2.Name;
        //Upgrade_DescriptionText3.text = Upgrade_3.Name;
        //Upgrade_DescriptionText4.text = Upgrade_4.Name;
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
            if(money >= 15f){
                money -= 15f;
                stockSaleSpeed += 0.01f;
                upgradeSound.Play();
                oompaLoompa.SetActive(true);
                RemoveUpgrade("Oompa Loompas");
            }
            Debug.Log("Oompa Loompas");
        }
        else if (upgradeChosen == "Chocolate Tasting Room"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Chocolate Tasting Room");
            }
            Debug.Log("Chocolate Tasting Room");
        }
        else if (upgradeChosen == "Bubblegum"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                rightFactory.enabled = true;
                GumStock.enabled = true;
                gumAvailable = true;
                RemoveUpgrade("Bubblegum");
            }
            Debug.Log("Bubblegum");
        }
        else if (upgradeChosen == "New flavor - Breakfast"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("New flavor - Breakfast");
            }
            Debug.Log("New flavor - Breakfast");
        }
        else if (upgradeChosen == "New flavor - Lunch"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("New flavor - Lunch");
            }
            Debug.Log("New flavor - Lunch");
        }
        else if (upgradeChosen == "New flavor - Dinner"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("New flavor - Dinner");
            }
            Debug.Log("New flavor - Dinner");
        }
        else if (upgradeChosen == "OompaLoompa Housing"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                topFactory.enabled = true;
                RemoveUpgrade("OompaLoompa Housing");
            }
            Debug.Log("New flavor - Dinner");
        }
        else if (upgradeChosen == "3-Course's Dinner Gum"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("3-Course's Dinner Gum");
            }
            Debug.Log("3-Course's Dinner Gum");
        }
        else if (upgradeChosen == "Gobstoppers"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                leftFactory.enabled = true;
                GobstopperStock.enabled = true;
                gobAvailable = true;
                RemoveUpgrade("Gobstoppers");
            }
            Debug.Log("Gobstoppers");
        }
        else if (upgradeChosen == "New flavors"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("New flavors");
            }
            Debug.Log("New flavors");
        }
        else if (upgradeChosen == "A variety of flavors, One Gobstopper"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("A variety of flavors, One Gobstopper");
            }
            Debug.Log("A variety of flavors, One Gobstopper");
        }
        else if (upgradeChosen == "New recipe - Longer lasting"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("New recipe - Longer lasting");
            }
            Debug.Log("New recipe - Longer lasting");
        }
        else if (upgradeChosen == "Experimenting phase"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Experimenting phase");
            }
            Debug.Log("Experimenting phase");
        } 
        else if (upgradeChosen == "24h Gobstoppers!"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("24h Gobstoppers!");
            }
            Debug.Log("24h Gobstoppers!");
        }
        else if (upgradeChosen == "Everlasting Gobstoppers"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Everlasting Gobstoppers");
            }
            Debug.Log("Everlasting Gobstoppers");
        }
        else if (upgradeChosen == "Oompa Loompa Wellness program"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Oompa Loompa Wellness program");
            }
            Debug.Log("Oompa Loompa Wellness program");
        }
        else if (upgradeChosen == "Oompa Loompa Eficiency Training"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Oompa Loompa Eficiency Training");
            }
            Debug.Log("Oompa Loompa Eficiency Training");
        }
        else if (upgradeChosen == "Oompa Loompa Retirement plan"){
            if(money >= 15f){
                money -= 15f;
                upgrades += 1000f;
                upgradeSound.Play();
                RemoveUpgrade("Oompa Loompa Retirement plan");
            }
            Debug.Log("Oompa Loompa Retirement plan");
        }
    }

    public void OompaBuy(){
    if (rightFactory.enabled == false && oompaQuantity < 4){
        if(money >= 1f){
                money -= 1f; // alterar preco
                stockProductionSpeed += 0.2f; //cada oompa loompa acelera a velocidade de producao
                oompaQuantity += 1; 
                oompaVoice.Play();
        }
    }else if (rightFactory.enabled == true && oompaQuantity < 16){
        if(money >= 5f){
                money -= 5f; // alterar preco
                stockProductionSpeed += 0.2f; //cada oompa loompa acelera a velocidade de producao
                oompaQuantity += 1; 
                oompaVoice.Play();
        }
    }else if (topFactory.enabled == true && oompaQuantity < 19){
        if(money >= 10f){
                money -= 10f; // alterar preco
                stockProductionSpeed += 0.2f; //cada oompa loompa acelera a velocidade de producao
                oompaQuantity += 1; 
                oompaVoice.Play();
        }
    }else if (leftFactory.enabled == true && oompaQuantity < 29){
        if(money >= 15f){
                money -= 15f; // alterar preco
                stockProductionSpeed += 0.2f; //cada oompa loompa acelera a velocidade de producao
                oompaQuantity += 1; 
                oompaVoice.Play();
        }
    }

        // Surgir Oompa Loompas nas janelas
        if(oompaQuantity == 1){
            oompa1.enabled = true;
        }
        else if (oompaQuantity == 2) {
            oompa2.enabled = true;
        }
        else if (oompaQuantity == 3) {
            oompa3.enabled = true;
        }
        else if (oompaQuantity == 4) {
            oompa4.enabled = true;
        }   
        else if (oompaQuantity == 5) {
            oompa5.enabled = true;
        }
        else if (oompaQuantity == 6) {
            oompa6.enabled = true;
        }  
        else if (oompaQuantity == 7) {
            oompa7.enabled = true;
        }
        else if (oompaQuantity == 8) {
            oompa8.enabled = true;
        }
        else if (oompaQuantity == 9) {
            oompa9.enabled = true;
        }
        else if (oompaQuantity == 10) {
            oompa10.enabled = true;
        }
        else if (oompaQuantity == 11) {
            oompa11.enabled = true;
        }
        else if (oompaQuantity == 12) {
            oompa12.enabled = true;
        }
        else if (oompaQuantity == 13) {
            oompa13.enabled = true;
        }
        else if (oompaQuantity == 14) {
            oompa14.enabled = true;
        }
        else if (oompaQuantity == 15) {
            oompa15.enabled = true;
        }
        else if (oompaQuantity == 16) {
            oompa16.enabled = true;
        }
        else if (oompaQuantity == 17) {
            oompa17.enabled = true;
        }
        else if (oompaQuantity == 18) {
            oompa18.enabled = true;
        }
        else if (oompaQuantity == 19) {
            oompa19.enabled = true;
        }
        else if (oompaQuantity == 20) {
            oompa20.enabled = true;
        }
        else if (oompaQuantity == 21) {
            oompa21.enabled = true;
        }
        else if (oompaQuantity == 22) {
            oompa22.enabled = true;
        }
        else if (oompaQuantity == 23) {
            oompa23.enabled = true;
        }     
        else if (oompaQuantity == 24) {
            oompa24.enabled = true;
        }
        else if (oompaQuantity == 25) {
            oompa25.enabled = true;
        }
        else if (oompaQuantity == 26) {
            oompa26.enabled = true;
        }  
        else if (oompaQuantity == 27) {
            oompa27.enabled = true;
        }  
        else if (oompaQuantity == 28) {
            oompa28.enabled = true;
        }  
        else if (oompaQuantity == 29) {
            oompa29.enabled = true;
        }
   
    }


    public class Upgrade{
        public string Name { get; set; }
        public string Description { get; set; }
        public string Boost { get; set; }
        public string Cost { get; set; }

        public int Order { get; set; }
    }
}
