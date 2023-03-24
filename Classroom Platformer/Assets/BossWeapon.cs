using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;


    public Vector3 attackOffest;
    public float attackRange = 1f;
    public LayerMask attackMask;



    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffest.x;
        pos += transform.up * attackOffest.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        
        
    }
}
