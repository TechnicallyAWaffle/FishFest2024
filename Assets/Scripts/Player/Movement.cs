
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    SwimParticleEmitter swimParticleEmitterPrefab;

    [SerializeField]
    public float maxSpeed = 50f;

    [SerializeField]
    float baseSwimSpeed = 15f;

    [SerializeField]
    float dashSpeed = 15f;

    [SerializeField]
    float dashDecayRate = 50f;

    [SerializeField]
    float distanceToMouse = 2f;

    [SerializeField]
    Transform bodySprite;

    public bool IsMoving => isMoving;

    Rigidbody2D rb2d;

    Vector2 mousePos;

    Vector2 mouseWorldPos;

    Vector2 mousePath;

    float mouseDistance;

    float mouseAngle;

    private float currentSwimSpeed;
    bool isMoving = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private bool IsAwayFromMouse()
    {
        return mouseDistance > distanceToMouse;
    }

    private void HaltFish()
    {
        rb2d.velocity = Vector2.zero;
        currentSwimSpeed = 0f;
    }

    private void SwimTowardsMouse()
    {
        rb2d.angularVelocity = 0;
        rb2d.velocity = mousePath.normalized * currentSwimSpeed;
    }

    private float GetAngleToMouse(Vector2 direction)
    {
        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;

        return angleDeg;
    }

    public void GameUpdate()
    {
        if (!isMoving) return;

        mousePos = Mouse.current.position.ReadValue();
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 playerPos = new(transform.position.x, transform.position.y);

        mousePath = mouseWorldPos - playerPos;
        mouseDistance = Vector2.Distance(playerPos, mouseWorldPos);
        mouseAngle = GetAngleToMouse(mousePath);

        UpdateSwimSpeed();
    }

    private void UpdateSwimSpeed()
    {
        currentSwimSpeed -= dashDecayRate * Time.deltaTime;
        if (currentSwimSpeed <= baseSwimSpeed)
        {
            currentSwimSpeed = baseSwimSpeed;
        }

        currentSwimSpeed = Mathf.Clamp(currentSwimSpeed, baseSwimSpeed, maxSpeed);
    }

    public void GameFixedUpdate()
    {
        if (!isMoving) return;

        if (IsAwayFromMouse())
        {
            SwimTowardsMouse();
            bodySprite.rotation = Quaternion.Euler(0, 0, mouseAngle);
        }
        else
        {
            HaltFish();
        }
    }

    public void Dash()
    {
        if (isMoving && IsAwayFromMouse())
        {
            currentSwimSpeed += dashSpeed;
            SwimParticleEmitter swimEmitter = Instantiate(swimParticleEmitterPrefab, transform.position, Quaternion.identity);
            swimEmitter.EmitAwayFromDirection(mouseAngle);
            swimEmitter.SelfDestructInASecond();
        }
    }

    public void SetMovementState(bool state)
    {
        isMoving = state;

        if (isMoving == false)
        {
            HaltFish();
        }
    }
}
