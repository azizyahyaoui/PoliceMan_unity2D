
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    [SerializeField]
    AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySoundAt(sound, transform.position);
            
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.numCoinsPickUp++;
            Destroy(gameObject);
        }
           
    }
   
    
}
