using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.RightArrow) ^ Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * inputX * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S) ^ Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.up * inputY * speed * Time.deltaTime);
        }
    }
}
