using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthPlayerUP : MonoBehaviour
{
    [SerializeField]
    AudioClip upHealthSound;

    private int healthPoints =10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HealthPlayer.instance.currentHealth < HealthPlayer.instance.maxHealth)
            {
                HealthPlayer.instance.PlayerHealthUp(healthPoints);
                AudioManager.instance.PlaySoundAt(upHealthSound, transform.position);

                Destroy(gameObject);
            }
            
        }

    }

}
