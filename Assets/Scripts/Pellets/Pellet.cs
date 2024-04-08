using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    [SerializeField]
    float expireTime = 15f;

    Rigidbody2D rb2d;
    Collider2D col;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        Destroy(this.gameObject, expireTime);
    }

    public void AddForce(Vector2 direction)
    {
        rb2d.AddForce(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            Debug.Log("TODO: Deal damage to enemy");
        }
    }
}
