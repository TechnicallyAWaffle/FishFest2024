using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    SwimParticleEmitter swimParticleEmitterPrefab;

    [SerializeField]
    float maxSpeed = 50f;

    [SerializeField]
<<<<<<< HEAD:Assets/Scripts/Movement/Movement.cs
    float baseSwimSpeed = 15f;
=======
    float dashForce = 20f;
>>>>>>> main:Assets/Scripts/Player/Movement.cs

    [SerializeField]
    float dashSpeed = 15f;

    [SerializeField]
    float dashDecayRate = 50f;

    [SerializeField]
    float distanceToMouse = 2f;

    [SerializeField]
    Transform bodySprite;

    Rigidbody2D rb2d;

    Vector2 mousePos;

    Vector2 mouseWorldPos;

    Vector2 mousePath;

    float mouseDistance;

    float mouseAngle;

<<<<<<< HEAD:Assets/Scripts/Movement/Movement.cs
    private float currentSwimSpeed;
    bool isMoving = false;

    private void Awake()
=======
    bool isDashing = false;
    float dashTimeElapsed = 0f;
    private void Awake() 
>>>>>>> main:Assets/Scripts/Player/Movement.cs
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
        } else
        {
<<<<<<< HEAD:Assets/Scripts/Movement/Movement.cs
            HaltFish();
=======
            //A normalized vector preserves the direction of the original vector while reducing the magnitude to 1 or the smallest unit.
            //The velocity of the rigid body is in the direction of the mousePath at the magnitude swimSpeed
            rb2d.velocity = mousePath;//.normalized * swimSpeed; //<-- removal of this makes speed directly correlated to distance of mouse (i.e. slower closer, faster further)
>>>>>>> main:Assets/Scripts/Player/Movement.cs
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