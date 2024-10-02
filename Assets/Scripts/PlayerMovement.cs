using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;

    float movementSpeed = 3.0f;
    float rotationSpeed = 100.0f;

    [SerializeField] Vector2 moveValues;

    Rigidbody rbody;

    bool grounded = true;

    [SerializeField] float forceValue;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValues = moveAction.ReadValue<Vector2>();

        if (jumpAction.ReadValue<float>() == 1 && grounded)
        {
            grounded = false;
            rbody.AddRelativeForce(Vector3.up * forceValue, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime * moveValues.y);
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime * moveValues.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    public void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }
}
