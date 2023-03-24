using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int playerhealth = 100;
    public GameObject deathEffect;
    public void TakeDamage(int damage)
    {
        playerhealth -= damage;

        animator.SetTrigger("Hurt");

        if (playerhealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
