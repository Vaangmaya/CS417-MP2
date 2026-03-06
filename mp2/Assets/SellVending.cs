using UnityEngine;
using System.Collections;

public class SellVending : MonoBehaviour
{
    public float vendTime = 3.0f;
    public float vendValue = 3.0f;

    private MoneyCounter moneyManager;
    private VendingCount vendingCount;

    void Start()
    {
        moneyManager = Object.FindFirstObjectByType<MoneyCounter>();
        vendingCount = Object.FindFirstObjectByType<VendingCount>();
        StartCoroutine(VendingLoop());
    }

    IEnumerator VendingLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(vendTime);
            SellItem();
        }
    }

    void SellItem()
    {
        moneyManager.AddMoney(vendValue);
        vendingCount.RegisterSale();
    }
}