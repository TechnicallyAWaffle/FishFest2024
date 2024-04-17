
using Ink.Parsed;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementMod
{
    public string Name;
    public float Value;

    public MovementMod(string name, float value)
    {
        this.Name = name;
        this.Value = value;
    }
}

public class Movement : MonoBehaviour
{
    [SerializeField]
    SwimParticleEmitter swimParticleEmitterPrefab;

    [SerializeField]
    float baseMaxSpeed = 50f;

    [SerializeField]
    float baseSwimSpeed = 15f;

    [SerializeField]
    float baseDashSpeed = 15f;

    [SerializeField]
    float dashDecayRate = 50f;

    [SerializeField]
    float distanceToMouse = 2f;

    [SerializeField]
    Transform bodySprite;

    private readonly List<MovementMod> swimSpeedModifiers = new();
    private readonly List<MovementMod> dashSpeedModifiers = new();
    [SerializeField] private float currentMinSpeed;
    [SerializeField] private float currentSwimSpeed;
    [SerializeField] private float currentDashSpeed;
    [SerializeField] private float currentMaxSpeed;

    public bool IsMoving => isMoving;

    Rigidbody2D rb2d;

    Vector2 mousePos;

    Vector2 mouseWorldPos;

    Vector2 mousePath;

    float mouseDistance;

    float mouseAngle;

    bool isMoving = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //-- UPDATE FUNCTIONS
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

    public void GameUpdate()
    {
        if (!isMoving) return;

        mousePos = Mouse.current.position.ReadValue();
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 playerPos = new(transform.position.x, transform.position.y);

        mousePath = mouseWorldPos - playerPos;
        mouseDistance = Vector2.Distance(playerPos, mouseWorldPos);
        mouseAngle = GetAngleToMouse(mousePath);

        UpdateCurrentMinSpeed();
        UpdateCurrentMaxSpeed();
        UpdateCurrentDashSpeed();
        UpdateSwimSpeed();
    }

    //-- PUBLIC FUNCTIONS

    public void Dash()
    {
        if (isMoving && IsAwayFromMouse())
        {
            currentSwimSpeed += currentDashSpeed;
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

    public void AddSwimMod(MovementMod mod)
    {
        swimSpeedModifiers.Add(mod);
    }
    public void RemoveSwimMod(MovementMod mod)
    {
        swimSpeedModifiers.Remove(mod);
    }

    public void AddDashMod(MovementMod mod)
    {
        dashSpeedModifiers.Add(mod);
    }
    public void RemoveDashMod(MovementMod mod)
    {
        dashSpeedModifiers.Remove(mod);
    }

    //-- HELPERS

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

    // Calculates the current min speed from base swim + any modifiers to swim
    private void UpdateCurrentMinSpeed()
    {
        currentMinSpeed = baseSwimSpeed;
        foreach (var mod in swimSpeedModifiers)
        {
            currentMinSpeed += mod.Value;
        }
    }

    // Sets the max speed to the base max + any modifiers to swim & dash
    private void UpdateCurrentMaxSpeed()
    {
        currentMaxSpeed = baseMaxSpeed;
        foreach (var mod in swimSpeedModifiers)
        {
            currentMaxSpeed += mod.Value;
        }
        foreach (var mod in dashSpeedModifiers)
        {
            currentMaxSpeed += mod.Value;
        }
    }

    // Sets the current dash speed to base + any mods to dash
    private void UpdateCurrentDashSpeed()
    {
        currentDashSpeed = baseDashSpeed;
        foreach(var mod in dashSpeedModifiers)
        { 
            currentDashSpeed += mod.Value; 
        }
    }

    // Decays currentSwimSpeed & clamps the current swim speed between the current min and max speeds
    private void UpdateSwimSpeed()
    {
        currentSwimSpeed -= dashDecayRate * Time.deltaTime;
        currentSwimSpeed = Mathf.Clamp(currentSwimSpeed, currentMinSpeed, currentMaxSpeed);
    }
}
