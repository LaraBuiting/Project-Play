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

    void Start()
    {
        //Cache the transform
        thisTransform = this.transform;

        //Setting a random time delay for taking decisions
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        ChooseMoveDirection();
    }

    void Update()
    {
        thisTransform.position += directions[currentDirection] * Time.deltaTime * speed;

        if(decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            ChooseMoveDirection();
        }
    }

    void ChooseMoveDirection()
    {
        currentDirection = Mathf.FloorToInt(Random.Range(0, directions.Length));
    }
}
