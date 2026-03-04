using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay; 
    public float moneyCount = 0f;
    public float moneyRate = 5.0f; 

    void Update()
    {
        moneyCount += moneyRate * Time.deltaTime;

        if (moneyDisplay != null)
        {
            moneyDisplay.text = "Money: $" + moneyCount.ToString("F2");
        }
    }
}


