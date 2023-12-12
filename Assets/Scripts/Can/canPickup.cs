using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class canPickup : MonoBehaviour
{
    public TextMeshProUGUI MyCanAmountText;
    private int CanAmount;

    void Start()
    {
        CanAmount = 0;
        MyCanAmountText.text = "Dirty cans: " + CanAmount;
    }

    private void OnTriggerEnter2D(Collider2D Can)
    {
        if (Can.gameObject.CompareTag("Can"))
        {
            CanAmount++;
            Destroy(Can.gameObject);
            MyCanAmountText.text = "Dirty cans: " + CanAmount;
        }
    }
}
