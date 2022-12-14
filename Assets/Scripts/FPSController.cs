using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Rigidbody rb;
    private float movSpeed = 10f;
    private float rotSpeed = 10f;
    private Vector3 velocity;
    private new Transform camera;
    private float h;
    private float v;

    private void Start()
    {
        camera = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        velocity = Vector3.zero;

        var mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;
        var mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed;

        if (mouseX != 0) 
        {
            transform.Rotate(Vector3.up * mouseX * rotSpeed);
        }
        if (mouseY != 0) 
        {
            var angle = (camera.localEulerAngles.x - mouseY * rotSpeed + 360) % 360;
            if (angle > 180) 
            {
                angle -= 360f;
            }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }

    private void FixedUpdate()
    {
        if (h != 0 || v != 0) 
        {
            Vector3 direction = (transform.forward * v + transform.right * h).normalized;
            velocity = direction * movSpeed;
        }
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}