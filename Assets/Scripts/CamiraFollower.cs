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

    [SerializeField]
     float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    // Update is called once per frame


    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            Player.transform.position + posOffset,
            ref playerVelocity, timeOffset);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit ),
            transform.position.z
            );
    }

    // draw a box boundary limit to camera 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //top boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        //right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        //bottom boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left boundary liner
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
