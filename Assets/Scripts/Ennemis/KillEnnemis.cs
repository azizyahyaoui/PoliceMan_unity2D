using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemis : MonoBehaviour
{
    private int EnnemisHelth = 4;

    private SpriteRenderer Spren;

    [SerializeField]
    AudioClip killSound;
    // Start is called before the first frame update
    void Start()
    {
        Spren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            EnnemisHelth--;
            if(EnnemisHelth <=0)
            {
                KillSelf();
            }
        }

    }

    private void KillSelf()
    {
        AudioManager.instance.PlaySoundAt(killSound, transform.position);

        Destroy(gameObject);
    }
}
