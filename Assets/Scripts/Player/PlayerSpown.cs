using UnityEngine;

public class PlayerSpown : MonoBehaviour
{
    

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }

    
}
