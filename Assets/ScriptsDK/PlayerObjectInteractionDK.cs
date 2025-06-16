using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObjectInteractionDK : MonoBehaviour
{
    [SerializeField] private ObjectPickUpDK item;
    [SerializeField] private GameObject goal;
    private InputAction interact;
    private PlayerInput playerInput;
    public bool canMoveObject;
    public bool canDropObject;
    public bool objectPlaced;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        interact = playerInput.actions["Interact"];
    }

    private void Start()
    {
        if (item == null)
            item = FindAnyObjectByType<ObjectPickUpDK>();
    }

    private void OnEnable()
    {
        interact.performed += PickUpObject;
        interact.performed += LeaveObject;
    }

    private void OnDisable()
    {
        interact.performed -= PickUpObject;
        interact.performed -= LeaveObject;
    }

    private void PickUpObject(InputAction.CallbackContext context)
    {
        if (canMoveObject)
        {
            item.transform.parent = this.transform;
            item.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
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
