using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    private Rigidbody2D RB;

    public void SetAngle(Vector2 angle_vector, float force)
    {
        RB =  GetComponent<Rigidbody2D>();
        Vector2 _awakeVelocity = angle_vector * force;
        RB.velocity = _awakeVelocity;
        print(_awakeVelocity);
    }
}
