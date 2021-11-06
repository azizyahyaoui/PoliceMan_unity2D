using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    //******VARIABLES***************

    [HideInInspector]
    public Rigidbody2D rigbody;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
     float moveSpeed = 300f;
    private float NewX;

    private bool isJumpUp;
    [SerializeField]
     float jumpForce = 120f;

    private bool isGrounded;
    [SerializeField]
     Transform GroundCheck;
    float GroundCheckRadius =0.3f;
    [SerializeField]
    LayerMask groundMask; 
    private SpriteRenderer spriteRenderer;

    public float forceX;
    [HideInInspector]
    public Animator playerMVAnim;

    public static ControlPlayer instance;
    [HideInInspector]
    public Collider2D cd2D;
    //***************************************



    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of ControlPlayer on the scene ");
            return;
        }

        instance = this;

        rigbody = GetComponent<Rigidbody2D>();
        playerMVAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cd2D = GetComponent<Collider2D>();
    }

    //***************************************



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 510f;
            playerMVAnim.SetTrigger("IsRunning");
        }
            
        else
            moveSpeed = 360f;



        if ((Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.Space)) && isGrounded)
            isJumpUp = true;


        NewX = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
       

        Flip(rigbody.velocity.x);

        forceX = Mathf.Abs(rigbody.velocity.x);
        playerMVAnim.SetFloat("playerMVAnim", forceX);

    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, groundMask);


        MovePlayer(NewX); 

    }

    //***************************************

    //************MOVING_METHOD+controle************
    void MovePlayer(float NewX)
    {
        Vector3 TargetVelocity = new Vector2(NewX, rigbody.velocity.y);
        rigbody.velocity = Vector3.SmoothDamp(rigbody.velocity, TargetVelocity,ref velocity, 0.05f);

        if (isJumpUp == true)
        {
            rigbody.AddForce(new Vector2(0f, jumpForce));
            JumUpAnim();
            isJumpUp = false;
        }

    }

    private void JumUpAnim()
    {
        playerMVAnim.SetTrigger("IsJumping");
    }

    //***************FIXE_SENSE_OF_PLAYER************************


    void Flip(float _sens)
    {
        if (_sens > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_sens < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
            

    }
    public bool canAttack()
    {
        return Input.GetAxis("Horizontal") == 0 && isGrounded;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
    }


}
