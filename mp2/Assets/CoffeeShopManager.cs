using UnityEngine;

public class CoffeeShopManager : MonoBehaviour
{
    public GameObject machine2Parent;
    public GameObject machine3Parent;

    public GameObject machine2RealVisual;
    public GameObject machine2Ghost;
    public GameObject machine3RealVisual; 
    public GameObject machine3Ghost;

    public float priceForMachine2 = 500f;
    public float priceForMachine3 = 1000f;
    public float incomeBoost = 0.5f;

    private MoneyCounter moneySystem;
    private bool machine2Bought = false;

    void Start()
    {
        moneySystem = Object.FindFirstObjectByType<MoneyCounter>();

        machine2RealVisual.SetActive(false);
        machine3RealVisual.SetActive(false);
        
        machine2Ghost.SetActive(true);
        machine3Ghost.SetActive(false);
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

            moneySystem.AddPassiveRate(incomeBoost);
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
            machine3RealVisual.SetActive(true);
            machine3Ghost.SetActive(false);

            moneySystem.AddPassiveRate(incomeBoost);
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
}