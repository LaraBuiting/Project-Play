using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    internal Transform thisTransform;

    //NPC movement speed
    public float speed = 2f;

    //Minimum and maximum time it takes to decide which side to go
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    //The possible directions the NPC can move in
    internal Vector3[] directions = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero, Vector3.zero };
    internal int currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        //Cache the transform
        thisTransform = this.transform;

        //Setting a random time delay for taking decisions
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        //Calls the method ChooseMoveDirection
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the object in the chosen direction at a certain speed
        thisTransform.position += directions[currentDirection] * Time.deltaTime * speed;

        if(decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            //Choose a random time delay to decide which way to go
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

            //Calls the method ChooseMoveDirection
            ChooseMoveDirection();
        }
    }

    //Choose a movement direction or stay in place
    void ChooseMoveDirection()
    {
        //Choose whether to move sideways, up or down
        currentDirection = Mathf.FloorToInt(Random.Range(0, directions.Length));
    }
}
