using UnityEngine;
using TMPro;

public class CoffeeCounter : MonoBehaviour
{
    public TextMeshProUGUI coffeeDisplay;
    public int totalCoffeesSold = 0;

    public void RegisterSale()
    {
        totalCoffeesSold++;
        UpdateUI();
    }

    void UpdateUI()
    {
        coffeeDisplay.text = "Coffees Sold: " + totalCoffeesSold;
    }
}