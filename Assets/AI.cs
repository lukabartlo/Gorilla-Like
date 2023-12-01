using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class AI : MonoBehaviour
{
    [Header ("Stats")]
    public float EnemySpeed;
    public float StoppingDistance;
    public float NearDistance;
    public float StartTimeBtwShots;
    private float TimeBtwShot;

    [Header ("References")]
    public GameObject shoot;
    private Transform player;

    public GameObject GameEvent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameEvent = GameObject.Find("GameEvent");
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < NearDistance && GameEvent.GetComponent<GameEventScript>().PlayerTurn == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -EnemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > StoppingDistance && GameEvent.GetComponent<GameEventScript>().PlayerTurn == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, EnemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < NearDistance && Vector2.Distance(transform.position, player.position) < NearDistance && GameEvent.GetComponent<GameEventScript>().PlayerTurn == false)
        {
            transform.position = this.transform.position;
        }

        if (TimeBtwShot <= 0 && GameEvent.GetComponent<GameEventScript>().PlayerTurn == false) 
        {
            Instantiate(shoot, transform.position, Quaternion.identity);
            TimeBtwShot = StartTimeBtwShots;
        }
        else
        {
            TimeBtwShot -= Time.deltaTime;
        }
    }
}

