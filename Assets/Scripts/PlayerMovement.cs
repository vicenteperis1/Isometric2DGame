using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 movement;
    private Rigidbody2D playerRB;

    private PlayerInput playerInput;
    private InputAction moveAction;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        // Set interpolation for smoother movement
        playerRB.interpolation = RigidbodyInterpolation2D.Interpolate;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];// match the name in the Input Actions asset

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();

        // Normalize movement vector to prevent faster diagonal movement
        //if (movement.sqrMagnitude > 1f)
        //    movement.Normalize();

        Vector2 move = movement; // vector3 for movement
       // transform.TransformDirection(move); // convert local to global direction
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * speed * Time.fixedDeltaTime);
    }
}
