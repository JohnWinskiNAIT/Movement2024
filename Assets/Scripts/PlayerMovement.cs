using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;
    public InputAction lookAction;

    float movementSpeed = 3.0f;
    float rotationSpeed = 200.0f;
    float movementForce = 10.0f;
    float rotationForce = 5.0f;

    [SerializeField] Vector2 moveValues;
    [SerializeField] Vector2 lookValues;

    Rigidbody rbody;

    bool grounded = true;

    [SerializeField] float forceValue;

    [SerializeField] GameObject cam;

    [SerializeField] GameObject targetSphere;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValues = moveAction.ReadValue<Vector2>();
        lookValues = lookAction.ReadValue<Vector2>();

        if (jumpAction.ReadValue<float>() == 1 && grounded)
        {
            grounded = false;
            rbody.AddRelativeForce(Vector3.up * forceValue, ForceMode.Impulse);
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10.0f))
        {
            targetSphere.transform.position = hit.point;
        }
    }

    private void FixedUpdate()
    {
        // Move with force and torque
        rbody.AddRelativeForce(new Vector3(moveValues.x, 0, moveValues.y) * Time.fixedDeltaTime * movementForce, ForceMode.VelocityChange);
        rbody.AddTorque(Vector3.up * rotationForce * Time.fixedDeltaTime * lookValues.x, ForceMode.VelocityChange);
        
        // Move with translate and rotate
        //transform.Translate(new Vector3(moveValues.x, 0, moveValues.y) * Time.fixedDeltaTime * movementSpeed);
        //transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime * lookValues.x);
        
        cam.transform.Rotate(-Vector3.right, rotationSpeed * Time.fixedDeltaTime * lookValues.y);
    }

    private void LateUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    public void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        lookAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        lookAction.Disable();
    }
}
