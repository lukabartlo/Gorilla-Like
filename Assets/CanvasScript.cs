using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Quaternion target = Quaternion.Euler(0f,0f, player.GetComponent<Player>().MouseAngle);
        transform.rotation = target;
    }
}
