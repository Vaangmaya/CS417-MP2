using UnityEngine;
using TMPro;

public class VendingCount : MonoBehaviour
{
    public TextMeshProUGUI vendingDisplay;
    public int totalVendingsSold = 0;

    public void RegisterSale(int count)
    {
        totalVendingsSold += count;
        UpdateUI();
    }

    void UpdateUI()
    {
        vendingDisplay.text = "Vendings Sold: " + totalVendingsSold;
    }
}