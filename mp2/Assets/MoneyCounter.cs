using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    public float moneyCount = 0f;
    public float multiplier = 1.0f;

    void Start()
    {
        UpdateUI();
    }

    public void AddMoney(float amount)
    {
        moneyCount += amount * multiplier;
        UpdateUI();
    }

    public void Update()
    {
        // might be used later?
    }

    void UpdateUI()
    {
        moneyDisplay.text = "Money: $" + moneyCount.ToString("F2");
    }
}