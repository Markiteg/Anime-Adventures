using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float Damage, Health;
    public float TimeBTWAttack, StartTimeBTWAttack;
    public GameObject AttackTrigger;
    public LayerMask enemy;
    private Enemy enem;

    private bool IsEnemyTagert;

    void Start()
    {
        IsEnemyTagert = false;
        AttackTrigger = GameObject.FindWithTag("MeleAttackTrigger");
    }

    void Update()
    {
        if (Health > 0)
        {
            if (TimeBTWAttack <= 0)
                DamageEnemy();
            else
                TimeBTWAttack -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }

    public void DamageEnemy()
    {
        if (!IsEnemyTagert)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(AttackTrigger.transform.position, 3f, enemy);
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].tag == "Enemy")
                {
                    enem = col[i].GetComponent<Enemy>();
                    IsEnemyTagert = true;
                    break;
                }
            }
        }
        else
        {
            if (enem.hp > 0)
            {
                enem.TakeDamage(Damage);
                TimeBTWAttack = StartTimeBTWAttack;
            }
            else
                IsEnemyTagert = false;
        }
    }
}
