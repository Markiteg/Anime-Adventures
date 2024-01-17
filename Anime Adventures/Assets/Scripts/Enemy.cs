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

    private Rigidbody2D rb;
    private bool IsStop;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(trigger.transform.position, 0.1f, enemyMask);
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].tag == "Enemy" || col[i].tag == "Barrier")
                IsStop = true;
            else
                IsStop = false;
        }
        if (!IsStop)
        {
            rb.velocity = new Vector2(-5, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

    }
}
