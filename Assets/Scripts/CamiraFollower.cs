using UnityEngine;

public class CamiraFollower : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
     float timeOffset = 0.6f;
    [SerializeField]
     Vector3 posOffset;
    private Vector3 playerVelocity;
    // Update is called once per frame

   
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            Player.transform.position + posOffset,
            ref playerVelocity, timeOffset);
      
    }
}
