using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementDK : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction moveAction;

    public float speed = 5f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }
}