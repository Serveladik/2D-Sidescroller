using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth = 1f;

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            GameManager.Instance.Score++;
            Destroy(this.gameObject);
        }
    }
}
