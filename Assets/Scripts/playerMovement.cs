using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //If you press the basic sideways buttons the character moves sideways
        if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.RightArrow) ^ Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * inputX * speed * Time.deltaTime);
        }

        //If you press the basis up down buttons the character moves that way
        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S) ^ Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.up * inputY * speed * Time.deltaTime);
        }
    }

    //If you collide with the energy drink your speed gets faster for a little bit and your energy bar goes up you also get a 
    //empty energy drink can in your inventory which you have to delever to a trash can.
}
