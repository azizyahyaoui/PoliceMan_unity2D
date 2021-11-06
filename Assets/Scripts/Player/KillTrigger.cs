using System.Collections;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private Transform PlayerSpown;
    private Animator FadeSystem;
    // private bool IsDeadStatus = false;


    private void Awake()
    {
        PlayerSpown = GameObject.FindGameObjectWithTag("PlayerSpown").transform;
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //-------------Death_Zone-----------------
        if (collision.CompareTag("Player"))
        {

            StartCoroutine(PlayerRespown(collision));


        }
      

    }


    private IEnumerator PlayerRespown(Collider2D collision)
    {
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position= PlayerSpown.position;
    }
}
