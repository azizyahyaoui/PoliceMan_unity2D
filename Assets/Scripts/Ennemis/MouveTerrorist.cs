using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouveTerrorist : MonoBehaviour
{
    //******VARIABLES***************
      private Rigidbody2D regbodyTerrorist;
    public float speed = 2f;


    private int damageOnCollision = 20;
    //******************************

    void MovingTerrorist()
    {
        regbodyTerrorist.velocity = new Vector2(transform.localScale.x, 0) * speed;



    }

        // Start is called before the first frame update
        void Start()
    {
        regbodyTerrorist = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        MovingTerrorist();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthPlayer health = collision.transform.GetComponent<HealthPlayer>();
            health.playerDamage(damageOnCollision);
        }
    }
}


