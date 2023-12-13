using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float normalSpeed = 2.5f;
    public float energySpeed = 3.5f;
    public float speed = 2.5f;
    public float energyLost = 0.05f;
    public float energyGained = 4f;

    private bool Cooldown = false;

    private void Start()
    {
        StartCoroutine(energyDepletingCountdown(60f));
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //If you press the basic sideways buttons the character moves sideways
        if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.RightArrow) ^ Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * inputX * speed * Time.deltaTime);

            //If you press E then you gain speed because you drank some energy
            if (Input.GetKey(KeyCode.E) && Cooldown == false)
            {
                speed = energySpeed;
                GetComponent<currentEnergy>().loseEnergy(-energyGained);
                StartCoroutine(initiateCooldown(4f));
            }
        }

        //If you press the basis up down buttons the character moves that way
        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S) ^ Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.up * inputY * speed * Time.deltaTime);
            
            //If you press E then you gain speed because you drank some energy
            if (Input.GetKey(KeyCode.E) && Cooldown == false)
            {
                speed = energySpeed;
                GetComponent<currentEnergy>().loseEnergy(-energyGained);
                StartCoroutine(initiateCooldown(4f));
            }
        }
    }

    // IEnumerator is a function that goes through each step
    IEnumerator initiateCooldown(float seconds)
    {
        //wait for a couple of seconds
        yield return new WaitForSeconds(2f);
        //put the speed back to normal
        speed = normalSpeed;
        //turn the cooldown on
        Cooldown = true;
        //wait a few seconds
        yield return new WaitForSeconds(4f);
        //turn the cooldown off
        Cooldown = false;
        //wait a few seconds
        yield return new WaitForSeconds(25f);
        StartCoroutine(energyDepletingCountdown(25f));
    }

    IEnumerator energyDepletingCountdown(float seconds)
    {
        yield return new WaitForSeconds(30f);
        GetComponent<currentEnergy>().loseEnergy(energyLost);
        yield return new WaitForSeconds(30f);
    }
}
