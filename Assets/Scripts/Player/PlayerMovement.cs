using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField][Range(1, 10)] private float speed;
    [SerializeField][Range(1, 3)] private float dashSpeed;

    private float finalSpeed;
    private Vector3 moveDirection;

    private void Start()
    {
        finalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.Translate(finalSpeed * Time.deltaTime * moveDirection);
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        }
    }

    public void SetPlayerDirection(InputAction.CallbackContext context)
    {
        float mouseX = context.ReadValue<float>();
        mouseX = camera.ScreenToWorldPoint(new Vector3(mouseX, 0, 0)).x;

        GetComponent<SpriteRenderer>().flipX = (transform.position.x >= mouseX);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input != null)
        {
            moveDirection = new Vector3(input.x, input.y);
        }
    }
    
    public void OnDash(InputAction.CallbackContext context)
    {
        bool isDash = context.ReadValue<float>() > 0;

        if (isDash) finalSpeed = speed * dashSpeed;
        else finalSpeed = speed;
    }
}
