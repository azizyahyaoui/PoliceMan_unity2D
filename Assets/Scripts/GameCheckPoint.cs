using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCheckPoint : MonoBehaviour
{
    private Transform PlayerSpown;

    private void Awake()
    {
        PlayerSpown = GameObject.FindGameObjectWithTag("PlayerSpown").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Player"))
        {

            PlayerSpown.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }


    }
}