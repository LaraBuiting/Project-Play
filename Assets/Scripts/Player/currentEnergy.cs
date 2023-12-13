using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentEnergy : MonoBehaviour
{
    // SerializeField means that a non public variable can be changed in unity. A public variable is serializable by default
    [SerializeField] private float startingEnergy;
    public float EnergyAtTheMoment { get; private set; }

    private void Awake()
    {
        EnergyAtTheMoment = startingEnergy;
    }

    public void loseEnergy(float _damage)
    {
        EnergyAtTheMoment = Mathf.Clamp(EnergyAtTheMoment - _damage, 0, startingEnergy);

        //if (EnergyAtTheMoment > 0)
        //{
        //    //player loses energy
        //}
        //else
        //{
        //    //player loses
        //    //PlayerManager.isGameOver = true;
        //    //gameObject.SetActive(false);
        //}
    }
}
