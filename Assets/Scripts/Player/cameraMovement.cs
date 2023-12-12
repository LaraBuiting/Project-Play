using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform followTransform;

    void FixedUpdate()
    {
        this.transform.position = new Vector2(followTransform.position.x, followTransform.position.y);
    }
}
