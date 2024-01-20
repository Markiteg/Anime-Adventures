using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHero : MonoBehaviour
{
    public float Health;
    public float Damage;
    public float TimeBTWShoot, StartTimeBTWShoot;
    public GameObject bullet;
    public float offset;
    public GameObject RangeTrigger;
    public LayerMask enemy;
    public GameObject SpawnBullet;
    public GameObject Gun;
    
    private bool IsEnemyTarget;
    private Enemy enem;

    void Start()
    {
        IsEnemyTarget = false;
        RangeTrigger = GameObject.FindWithTag("RangeAttackTrigger");
    }
   
    void Update()
    {
        if (Health > 0)
        {
            if (TimeBTWShoot <= 0)
            {
                DamageEnemy();
            }
            else
                TimeBTWShoot -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }

    public void DamageEnemy()
    {
        if (!IsEnemyTarget)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(RangeTrigger.transform.position, 5f, enemy);
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].tag == "Enemy")
                {
                    enem = col[i].GetComponent<Enemy>();
                    IsEnemyTarget = true;
                    break;
                }
            }
        }
        else
        {
            if (enem.hp > 0)
            {
                Vector3 difference = enem.transform.position - transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                Gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

                Instantiate(bullet, SpawnBullet.transform.position, Gun.transform.rotation);
                TimeBTWShoot = StartTimeBTWShoot;
            }
            else
                IsEnemyTarget = false;
        }
    }
}
