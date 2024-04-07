using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    [SerializeField]
    SwimParticleEmitter swimParticleEmitterPrefab;

    [SerializeField]
    float swimSpeed = 15f;

    [SerializeField]
    float dashForce = 5f;

    [SerializeField]
    float dashTime = 0.25f;

    [SerializeField]
    Transform bodySprite;

    Rigidbody2D rb2d;
    Vector2 mousePos;
    Vector2 mouseWorldPos;
    Vector2 mousePath;
    float mouseDistance;
    float mouseAngle;

    bool isDashing = false;
    float dashTimeElapsed = 0f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 playerPos = new(transform.position.x, transform.position.y);

        mousePath = mouseWorldPos - playerPos;
        mouseDistance = Vector2.Distance(playerPos, mouseWorldPos);
        mouseAngle = GetAngleToMouse(mousePath);
    }

    private void FixedUpdate()
    {
        Debug.Log(mouseDistance);

        if (IsAwayFromMouse())
        {
            SwimTowardsMouse();
            bodySprite.rotation = Quaternion.Euler(0, 0, mouseAngle);
        }
        else
        {
            HaltFish();
            bodySprite.rotation = Quaternion.identity;
        }

        dashTimeElapsed += Time.deltaTime;
        if (dashTimeElapsed > dashTime)
        {
            isDashing = false;
        }
    }

    private bool IsAwayFromMouse()
    {
        return mouseDistance > 0.25f;
    }

    private void HaltFish()
    {
        rb2d.velocity = Vector2.zero;
    }

    private void SwimTowardsMouse()
    {
        if (!isDashing)
        {
            rb2d.velocity = mousePath.normalized * swimSpeed;
        }
    }

    public void Dash(CallbackContext context)
    {
        if (context.performed && IsAwayFromMouse())
        {
            isDashing = true;
            dashTimeElapsed = 0f;

            rb2d.AddForce(mousePath.normalized * dashForce, ForceMode2D.Impulse);

            SwimParticleEmitter swimEmitter = Instantiate(swimParticleEmitterPrefab, transform.position, Quaternion.identity);
            swimEmitter.EmitAwayFromDirection(mouseAngle);
            swimEmitter.SelfDestructInASecond();
        }
    }

    private float GetAngleToMouse(Vector2 direction)
    {
        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;

        return angleDeg;
    }
}
