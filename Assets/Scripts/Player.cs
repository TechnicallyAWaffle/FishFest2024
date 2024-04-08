using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public SpriteRenderer BodySpriteRenderer;
    public Movement movementSystem;
    public PelletShooter PelletShooter;

    public bool Invincible = false;
    public bool Invisible = false;

    private void Awake()
    {
        // Destroy if already exists
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        movementSystem.GameUpdate();
        MutationManager.Instance.TickCurrentPassive();
    }

    private void FixedUpdate()
    {
        movementSystem.GameFixedUpdate();
    }

    public void MovementAction(CallbackContext context)
    {
        if (context.started)
        {
            movementSystem.SetMovementState(true);
        }

        if(context.canceled)
        {
            movementSystem.SetMovementState(false);
        }
    }

    public void AbilityKey1(CallbackContext context)
    {
        if (context.performed)
        {
            movementSystem.Dash();
        }
    }

    public void AbilityKey2(CallbackContext context)
    {
        if (context.performed)
        {
            MutationManager.Instance.ActivateCurrentAbility();
        }
    }
}
