using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDepleting : MonoBehaviour
{
    // SerializeField means that a non public variable can be changed in unity. A public variable is serializable by default
    [SerializeField] private float startingEnergy;
    [SerializeField] private currentEnergy playerEnergy;
    [SerializeField] private Image totalEnergyBar;
    [SerializeField] private Image currentEnergyBar;


    private void Start()
    {
        totalEnergyBar.fillAmount = playerEnergy.EnergyAtTheMoment / 10;
    }
    private void Update()
    {
        currentEnergyBar.fillAmount = playerEnergy.EnergyAtTheMoment / 10;
    }
}
