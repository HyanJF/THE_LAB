using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementDK : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField] private InputActionReference interact;

    [SerializeField] private ObjectPickUpDK item;
    [SerializeField] private GameObject goal;
    public bool canMoveObject;
    public bool canDropObject;
    public bool objectPlaced;

    public float speed = 5f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        item = FindAnyObjectByType<ObjectPickUpDK>();
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        interact.action.performed += PickUpObject;
        interact.action.performed += LeaveObject;
    }

    private void OnDisable()
    {
        interact.action.performed -= PickUpObject;
        interact.action.performed -= LeaveObject;
    }

    private void PickUpObject(InputAction.CallbackContext context)
    {
        if (canMoveObject)
        { 
            item.transform.parent = this.transform;
            item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
            objectPlaced = false;
        }
    }
    
    private void LeaveObject(InputAction.CallbackContext context)
    {
        if (canDropObject)
        {
            item.transform.SetParent(null);
            item.transform.position = new Vector3(goal.transform.position.x, goal.transform.position.y + 0.5f, goal.transform.position.z);
            objectPlaced = true;
        }
    }
}
