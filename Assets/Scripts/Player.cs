using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Movement movementSystem;
    public Bite bite;

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
        bite.GameUpdate();
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
            // Here
        }
    }

    // routes press RMB and release RMB to bite script on player 
    public void Bite(CallbackContext context)
    {
        if(context.started) bite.StartBite();
        else if(context.canceled) bite.StopBite();
        // ignore context.performed  lmaoooo
    }
}
