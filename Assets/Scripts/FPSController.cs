using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Rigidbody rb;
    private float movSpeed = 10f;
    private float rotSpeed = 10f;
    private Vector3 velocity;
    public new Transform camera;
    private float h;
    private float v;
    private bool getObj;

    [Header("Interactable Objetcs")]
    public GameObject pB;

    private void Start()
    {
        camera = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        getObj = false;
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

        var rayDistance = 5f;
        RaycastHit hitInfo;
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);

        if (Physics.Raycast(camera.position, camera.forward, out hitInfo, rayDistance, LayerMask.GetMask("Interactable"))) 
        {
            getObj = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && getObj) 
        {
            pB.SetActive(false);
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
