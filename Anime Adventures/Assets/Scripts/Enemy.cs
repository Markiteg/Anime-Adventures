using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public float PosX;
    public float HealthPoint;
    public float Damage;
    public GameObject trigger;
    public LayerMask enemyMask;
    public LayerMask BarrierMask;
    public bool IsStop;

    private Rigidbody2D rb;
     
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(trigger.transform.position, 0.1f, enemyMask);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].tag == "Enemy")
            {
                IsStop = true;
            }
            else if (col[i].tag != "Enemy" && transform.position.x < PosX)
                IsStop = false;
        }
        if (transform.position.x < PosX)
            IsStop = true;

        if (!IsStop)
        {
            rb.velocity = new Vector2(Speed * -1, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (HealthPoint <= 0)
            Destroy(gameObject);
    }
    public void TakeDamage(float dmg)
    {
        HealthPoint -= dmg;
    }

    public float hp { get { return HealthPoint; } }
}
