using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [HideInInspector]
     public int maxHealth =100;
    public int currentHealth;
    [SerializeField]
    HealthBar healthBar;

    [SerializeField] bool isNotAttackable= false;
    private SpriteRenderer spriteRenderer;
    private float flashDelay =0.15f;
    [SerializeField]
    AudioClip hitSound;

    public static HealthPlayer instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of HealthPlayer on the scene ");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            playerDamage(20);
    }
    public void PlayerHealthUp(int healthPoint)
    {
        if ((currentHealth + healthPoint)> maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthPoint;
        }
        
        healthBar.setHealth(currentHealth);
    }

    public void playerDamage(int damage)
    {
        if(!isNotAttackable)
        {
            AudioManager.instance.PlaySoundAt(hitSound, transform.position);

            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            if(currentHealth <= 0)
            {
                RIPPlayer();
                return;
            }


            isNotAttackable = true;
            StartCoroutine(IsNotAttackableFlash());
            StartCoroutine(FlashStop());
        }

    }

    private void RIPPlayer()
    {


        Debug.Log(message: "Popo is Dead");
        ControlPlayer.instance.enabled = false;
        ControlPlayer.instance.playerMVAnim.SetTrigger("Death");
        ControlPlayer.instance.rigbody.bodyType = RigidbodyType2D.Kinematic;
        ControlPlayer.instance.rigbody.velocity = Vector3.zero;
        ControlPlayer.instance.cd2D.enabled = false;
        GameOverManager.instance.OnPlayerDeath();

    }

    public void PlayerReload()
    {

        
        ControlPlayer.instance.enabled = true;
        ControlPlayer.instance.playerMVAnim.SetTrigger("PlayerReloadFromDeath");
        ControlPlayer.instance.rigbody.bodyType = RigidbodyType2D.Dynamic;
        ControlPlayer.instance.cd2D.enabled = true;
        GameOverManager.instance.OnPlayerDeath();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public IEnumerator IsNotAttackableFlash()
    {
        while(isNotAttackable)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(flashDelay);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(flashDelay);

        }

    }

    IEnumerator FlashStop()
    {
        yield return new WaitForSeconds(3f);
        isNotAttackable = false;
    }

}
