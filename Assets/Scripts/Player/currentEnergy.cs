using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentEnergy : MonoBehaviour
{
    public float startingEnergy;
    public float EnergyAtTheMoment { get; set; }

    private void Awake()
    {
        EnergyAtTheMoment = startingEnergy;
    }

    public void loseEnergy(float _damage)
    {
        EnergyAtTheMoment = Mathf.Clamp(EnergyAtTheMoment - _damage, 0, startingEnergy);

        if (EnergyAtTheMoment > 0)
        {
            GameOverMenu.isGameOver = false;
        }
        else
        {
            GameOverMenu.isGameOver = true;
        }
    }
}
