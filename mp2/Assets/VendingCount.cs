using UnityEngine;
using TMPro;

public class VendingCount : MonoBehaviour
{
    public TextMeshProUGUI vendingDisplay;
    public float totalVendingsSold = 0f;
    public float passiveRate = 0.1f;

    public void Update()
    {
        totalVendingsSold += passiveRate * Time.deltaTime;
        UpdateUI();
    }

    public void SetZero()
    {
        totalVendingsSold = 0f;
    }

    public void RegisterSale(float count)
    {
        totalVendingsSold += count;
    }

    void UpdateUI()
    {
        vendingDisplay.text = "Vendings Sold: " + totalVendingsSold.ToString("F1");
    }
}