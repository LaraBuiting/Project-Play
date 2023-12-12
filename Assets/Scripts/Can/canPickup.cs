using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Can)
    {
        if (Can.gameObject.CompareTag("Can"))
        {
            Destroy(Can.gameObject);
        }
    }
}
