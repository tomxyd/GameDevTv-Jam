using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private CharacterController charController;

    [SerializeField] private float speed = 20f;

    float gravity = -9.8f;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(deltaX, 0, deltaY);

        movement.y += gravity * Time.deltaTime;

        movement = Vector3.ClampMagnitude(movement, speed);
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }
}
