using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float normalSpeed = 2.5f;
    public float energySpeed = 3.5f;
    public float speed = 2.5f;
    public float energyLost = 0.5f;
    public float energyGained = 5f;

    private Animator anim;

    private float xInput;
    private float yInput;
    private bool speedCooldown = false;
    private bool eneryCooldown = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("aOrdPressed", true);
            transform.Translate(Vector2.right * xInput * speed * Time.deltaTime);

            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            anim.SetBool("aOrdPressed", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("wPressed", true);
            transform.Translate(Vector2.up * yInput * speed * Time.deltaTime);
        }else
        {
            anim.SetBool("wPressed", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("sPressed", true);
            transform.Translate(Vector2.up * yInput * speed * Time.deltaTime);
        }else
        {
            anim.SetBool("sPressed", false);
        }

        //If you press E then you gain speed because you drank some energy
        if (Input.GetKey(KeyCode.E) && speedCooldown == false)
        {
            speed = energySpeed;
            GetComponent<currentEnergy>().loseEnergy(-energyGained);
            StartCoroutine(initiateCooldown(10f));
        }

        if (eneryCooldown == false)
        {
            StartCoroutine(energyDepletingCountdown(10f)); 
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
        speedCooldown = true;
        //wait a few seconds
        yield return new WaitForSeconds(2f);
        //turn the cooldown off
        speedCooldown = false;
        eneryCooldown = true;
        //wait a few seconds
        yield return new WaitForSeconds(5f);
        eneryCooldown = false;
    }

    IEnumerator energyDepletingCountdown(float seconds)
    {
        eneryCooldown = true;
        GetComponent<currentEnergy>().loseEnergy(energyLost);
        yield return new WaitForSeconds(2f);
        eneryCooldown = false;
    }
}
