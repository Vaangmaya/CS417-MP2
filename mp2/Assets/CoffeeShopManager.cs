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

    public float passiveNormal = 0.5f;
    public float passiveUpgraded = 1.0f;

    private MoneyCounter moneySystem;
    private bool machine2Bought = false;
    private bool machine3Bought = false;
    private bool upgraded1Bought = false;

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
            upgraded2RealVisual.SetActive(true);
            upgraded2Ghost.SetActive(false);

            moneySystem.AddPassiveRate(passiveUpgraded);
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
}