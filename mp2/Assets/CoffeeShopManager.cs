using UnityEngine;

public class CoffeeShopManager : MonoBehaviour
{
    public GameObject machine2Parent;
    public GameObject machine3Parent;
    public GameObject upgraded1Parent;
    public GameObject upgraded2Parent;

    public GameObject machine2RealVisual;
    public GameObject machine2Ghost;
    public GameObject machine3RealVisual; 
    public GameObject machine3Ghost;
    public GameObject upgraded1RealVisual;
    public GameObject upgraded1Ghost;
    public GameObject upgraded2RealVisual;
    public GameObject upgraded2Ghost;

    public float priceForMachine2 = 500f;
    public float priceForMachine3 = 1000f;
    public float priceForUpgraded1 = 1500f;
    public float priceForUpgraded2 = 2000f;
    public float priceForWall = 3000f;
    public float priceForVending1 = 4000f;
    public float priceForVending2 = 6500f;
    public float priceForVending3 = 10000f;

    public float passiveNormal = 0.5f;
    public float passiveUpgraded = 5.0f;
    public float passiveVending = 50.0f;

    private MoneyCounter moneySystem;
    private bool machine2Bought = false;
    private bool machine3Bought = false;
    private bool upgraded1Bought = false;
    private bool upgraded2Bought = false;
    private bool wallBought = false;
    private bool vending1Bought = false;
    private bool vending2Bought = false;

    public GameObject realWall;
    public GameObject ghostWall;
    public GameObject wallPurchasePrompt;
    public GameObject vendingStatsDisplay;

    public GameObject vending1;
    public GameObject vending2;
    public GameObject vending3;
    public GameObject vending1Ghost;
    public GameObject vending2Ghost;
    public GameObject vending3Ghost;
    public GameObject vending1Real;
    public GameObject vending2Real;
    public GameObject vending3Real;

    void Start()
    {
        moneySystem = Object.FindFirstObjectByType<MoneyCounter>();

        machine2RealVisual.SetActive(false);
        machine3RealVisual.SetActive(false);
        
        machine2Ghost.SetActive(true);
        machine3Ghost.SetActive(false);

        upgraded1RealVisual.SetActive(false);
        upgraded2RealVisual.SetActive(false);

        upgraded1Ghost.SetActive(false);
        upgraded2Ghost.SetActive(false);

        realWall.SetActive(true);
        ghostWall.SetActive(false);
        wallPurchasePrompt.SetActive(false);
        vendingStatsDisplay.SetActive(false);
    }

    public void AttemptPurchaseMachine2()
    {
        if (moneySystem.moneyCount >= priceForMachine2 && !machine2Bought)
        {
            moneySystem.moneyCount -= priceForMachine2;
            machine2Bought = true;
            machine2RealVisual.SetActive(true);
            machine2Ghost.SetActive(false);
            
            machine3Ghost.SetActive(true);

            moneySystem.AddPassiveRate(passiveNormal);
        }
        else 
        {
            Debug.Log("Not enough money to buy Machine 2!");
        }
    }

    public void AttemptPurchaseMachine3()
    {
        if (machine2Bought && moneySystem.moneyCount >= priceForMachine3)
        {
            moneySystem.moneyCount -= priceForMachine3;
            machine3Bought = true;
            machine3RealVisual.SetActive(true);
            machine3Ghost.SetActive(false);

            upgraded1Ghost.SetActive(true);

            moneySystem.AddPassiveRate(passiveNormal);
        }
        else if (!machine2Bought)
        {
            Debug.Log("You must buy Machine 2 first!");
        }
        else 
        {
            Debug.Log("Not enough money to buy Machine 3!");
        }
    }

    public void AttemptPurchaseUpgraded1()
    {
        if (machine3Bought && moneySystem.moneyCount >= priceForUpgraded1)
        {
            moneySystem.moneyCount -= priceForUpgraded1;
            upgraded1Bought = true;
            upgraded1RealVisual.SetActive(true);
            upgraded1Ghost.SetActive(false);

            upgraded2Ghost.SetActive(true);

            moneySystem.AddPassiveRate(passiveUpgraded);
        }
        else if (!machine3Bought)
        {
            Debug.Log("You must buy Machine 3 first!");
        }
        else 
        {
            Debug.Log("Not enough money to buy Upgraded Machine 1!");
        }
    }

    public void AttemptPurchaseUpgraded2()
    {
        if (upgraded1Bought && moneySystem.moneyCount >= priceForUpgraded2)
        {
            moneySystem.moneyCount -= priceForUpgraded2;
            upgraded2Bought = true;
            upgraded2RealVisual.SetActive(true);
            upgraded2Ghost.SetActive(false);
            moneySystem.AddPassiveRate(passiveUpgraded);

            //make the wall ghost
            realWall.SetActive(false);
            ghostWall.SetActive(true);
            wallPurchasePrompt.SetActive(true);
        }
        else if (!upgraded1Bought)
        {
            Debug.Log("You must buy Upgraded Machine 1 first!");
        }
        else 
        {
            Debug.Log("Not enough money to buy Upgraded Machine 2!");
        }
    }

    public void AttemptPurchaseWall()
    {
        if (upgraded2Bought && moneySystem.moneyCount >= priceForWall)
        {
            Debug.Log("Wall purchased!");
            moneySystem.moneyCount -= priceForWall;
            ghostWall.SetActive(false);
            wallPurchasePrompt.SetActive(false);
            vendingStatsDisplay.SetActive(true);
            wallBought = true;

            vending1Ghost.SetActive(true);
        }
    }

    public void AttemptPurchaseVending1()
    {
        if (wallBought && moneySystem.moneyCount >= priceForVending1)
        {
            moneySystem.moneyCount -= priceForVending1;
            vending1Bought = true;
            vending1Real.SetActive(true);
            vending1Real.GetComponent<SellVending>().ActivateMachine();
            vending1Ghost.SetActive(false);

            vending2Ghost.SetActive(true);

            moneySystem.AddPassiveRate(passiveVending);
        }
        else if (!wallBought)
        {
            Debug.Log("You must buy Upgraded Machine 2 first!");
        }
        else 
        {
            Debug.Log("Not enough money to buy Vending Machine 1!");
        }
    }

    public void AttemptPurchaseVending2()
    {
        if (vending1Bought && moneySystem.moneyCount >= priceForVending2)
        {
            moneySystem.moneyCount -= priceForVending2;
            vending2Bought = true;
            vending2Real.SetActive(true);
            vending2Real.GetComponent<SellVending>().ActivateMachine();
            vending2Ghost.SetActive(false);

            vending3Ghost.SetActive(true);

            moneySystem.AddPassiveRate(passiveVending);
        }
        else if (!vending1Bought)
        {
            Debug.Log("You must buy Vending Machine 1 first!");
        }
        else 
        {
            Debug.Log("Not enough money to buy Vending Machine 2!");
        }
    }

    public void AttemptPurchaseVending3()
    {
        if (vending2Bought && moneySystem.moneyCount >= priceForVending3)
        {
            moneySystem.moneyCount -= priceForVending3;
            vending3Real.SetActive(true);
            vending3Real.GetComponent<SellVending>().ActivateMachine();
            vending3Ghost.SetActive(false);

            moneySystem.AddPassiveRate(passiveVending);
        }
        else if (!vending2Bought)
        {
            Debug.Log("You must buy Vending Machine 2 first!");
        }
        else 
        {
            Debug.Log("Not enough money to buy Vending Machine 3!");
        }
    }

    
}