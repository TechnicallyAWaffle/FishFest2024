using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Boolean nearPlayer = false;
    Rigidbody2D enemyrb2d;
    private void Awake()
    {
        enemyrb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (nearPlayer)
        {
            enemyrb2d.velocity = Vector2.up * 2;
        }
        else {
            enemyrb2d.velocity = Vector2.zero; 
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) //Player Layer is 3
        {
            nearPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) //Player Layer is 3
        {
            nearPlayer = false;
        }

    }
}
