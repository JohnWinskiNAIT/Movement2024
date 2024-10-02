using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f;
    float rotationSpeed = 300.0f;

    public InputAction moveAction;
    public InputAction rotationAction;

    [SerializeField] Vector2 moveValues;
    [SerializeField] Vector2 rotationValues;

    [SerializeField] GameObject turret;
    [SerializeField] GameObject barrel;

    Vector3 barrelAngles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the tank base

        //if (Keyboard.current.wKey.isPressed )
        //{
        //    transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        //}
        //if (Keyboard.current.sKey.isPressed)
        //{
        //    transform.Translate(new Vector3(0, 0, -1) * movementSpeed * Time.deltaTime);
        //}
        //transform.Rotate(0, Mouse.current.delta.ReadValue().x * rotationSpeed * Time.deltaTime, 0);

        #region Tank Movement
        moveValues = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime * moveValues.y);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * moveValues.x);

        rotationValues = rotationAction.ReadValue<Vector2>();

        turret.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * rotationValues.x);

        barrel.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime * rotationValues.y);

        barrelAngles = barrel.transform.localRotation.eulerAngles;
        if (barrelAngles.x > 10 && barrelAngles.x < 180)
        {
            barrel.transform.localRotation = Quaternion.Euler(10.0f, 0, 0);
        }
        if (barrelAngles.x > 180 && barrelAngles.x < 325)
        {
            barrel.transform.localRotation = Quaternion.Euler(325.0f, 0, 0);
        }
        #endregion

    }

    public void OnEnable()
    {
        moveAction.Enable();
        rotationAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
        rotationAction.Disable();
    }
}
