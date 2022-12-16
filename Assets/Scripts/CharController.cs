using UnityEngine;

public class CharController : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    float walkSpeed = 6.0f;
    float runSpeed = 10.0f;
    float gravity = 20.0f;

    [Header("Camera Rotation")]
    public Camera cam;
    float mouseH = 3.0f;
    float mouseV = 2.0f;
    float h_mouse, v_mouse;

    private Vector3 move = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        h_mouse = mouseH * Input.GetAxis("Mouse X");
        v_mouse += mouseV * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, -65f, 60f);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);
        transform.Rotate(0, h_mouse, 0);

        if (controller.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift)) move = transform.TransformDirection(move) * runSpeed;

            else move = transform.TransformDirection(move) * walkSpeed;
        }
        move.y -= gravity * Time.deltaTime;

        controller.Move(move * Time.deltaTime);
    }

}
