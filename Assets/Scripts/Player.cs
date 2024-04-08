using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    // Intro Scene
    public IntroManager introManager;

    // Main Scene
    public Movement movementSystem;
    public GameObject player;

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
        if (movementSystem == null) return;
        movementSystem.GameUpdate();
    }

    private void FixedUpdate()
    {
        if (movementSystem == null) return;
        movementSystem.GameFixedUpdate();
    }

    public void MovementAction(CallbackContext context)
    {
        if (context.performed)
        {
            if (introManager == null) return;
            introManager.NextScene();
        }
        

        /*if (context.started)
        {
            movementSystem.SetMovementState(true);
        }

        if(context.canceled)
        {
            movementSystem.SetMovementState(false);
        }*/
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
}
