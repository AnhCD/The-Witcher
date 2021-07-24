using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    
    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    public Animator anim;    
    
    private float currentHealth;

    private GameManager GM;

    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        anim = GetComponent<Animator>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0.0f)
        {
            anim.SetTrigger("dead");
            Die();
        }
    }

    private void Die()
    {
        GM.Respawn();
        Destroy(gameObject);
        
    }
}
