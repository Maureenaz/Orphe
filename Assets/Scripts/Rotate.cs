using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, MoveHorizontal * speed, 0);
    }
}
