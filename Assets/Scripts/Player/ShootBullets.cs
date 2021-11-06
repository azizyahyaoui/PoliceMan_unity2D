using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootBullets : MonoBehaviour
{
    private Animator anim;
    private ControlPlayer controlPlayer;
    private Object BulletRef;

    [SerializeField]
    float attackHoldDown = 0.05f;
    [SerializeField]
    float HoldDownTimer=20f;

    [SerializeField]
    Transform shootingPoint;

 
    private void Awake()
    {
        anim = GetComponent<Animator>();
        controlPlayer = GetComponent<ControlPlayer>();
        BulletRef = Resources.Load("shot0");
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1")&& HoldDownTimer > attackHoldDown && controlPlayer.canAttack())
            Attack();

        HoldDownTimer += Time.fixedDeltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attackpistol");
        HoldDownTimer = 0;

        //float direction is missing 
        GameObject Bullet = (GameObject)Instantiate(BulletRef);

             Bullet.transform.position = shootingPoint.position;
            Bullet.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, 1f);
        
      
    }

  


    

}
