using UnityEngine;
using System.Collections;

public class CoffeeMachine : MonoBehaviour
{
    public float brewTime = 3.0f;
    public float coffeeValue = 5.0f;
    public bool isAutomatic = false;

    public GameObject fincan;
    public GameObject kahve;
    public GameObject kurabiye;
    public GameObject tabak;
    
    private bool isBrewing = false;
    private bool coffeeReady = false;
    private MoneyCounter moneyManager;

    void Start()
    {
        moneyManager = Object.FindFirstObjectByType<MoneyCounter>();
        SetVisualState("Idle");
    }

    public void OnMachineClicked()
    {
        if (!isBrewing && !coffeeReady)
        {
            StartCoroutine(BrewCoffee());
        }
        else if (coffeeReady)
        {
            SellCoffee();
        }
    }

    IEnumerator BrewCoffee()
    {
        isBrewing = true;
        SetVisualState("Brewing");
        Debug.Log("Brewing...");
        
        yield return new WaitForSeconds(brewTime);
        
        isBrewing = false;
        coffeeReady = true;
        SetVisualState("Ready");
        Debug.Log("Coffee is Ready! Click to sell.");

        if (isAutomatic)
        {
            yield return new WaitForSeconds(0.5f);
            SellCoffee();
            yield return new WaitForSeconds(0.5f);
            OnMachineClicked(); 
        }
    }

    void SellCoffee()
    {
        moneyManager.AddMoney(coffeeValue);
        coffeeReady = false;
        SetVisualState("Idle");
        Debug.Log("Coffee Sold!");
    }

    void SetVisualState(string state)
    {
        tabak.SetActive(true);
        kurabiye.SetActive(true);

        if (state == "Idle")
        {
            fincan.SetActive(false);
            kahve.SetActive(false);
        }
        else if (state == "Brewing")
        {
            fincan.SetActive(true);
            kahve.SetActive(false);
        }
        else if (state == "Ready")
        {
            fincan.SetActive(true);
            kahve.SetActive(true);
        }
    }
}