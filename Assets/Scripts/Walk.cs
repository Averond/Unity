using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f; // zet op 0 als je geen springen wilt

    private CharacterController cc;
    private Vector3 velocity;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Input (WASD / arrow keys)
        float h = Input.GetAxisRaw("Horizontal"); // A/D, left/right
        float v = Input.GetAxisRaw("Vertical");   // W/S, up/down

        Vector3 inputDir = new Vector3(h, 0f, v);
        if (inputDir.sqrMagnitude > 1f) inputDir.Normalize();

        // camera-relative movement (optioneel)
        Vector3 camForward = Camera.main ? Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1)).normalized : Vector3.forward;
        Vector3 camRight = Camera.main ? Camera.main.transform.right : Vector3.right;
        Vector3 move = (camRight * inputDir.x + camForward * inputDir.z);

        // speed & move
        float targetSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Vector3 moveVelocity = move * targetSpeed;

        // rotate cube towards movement direction (if moving)
        if (move.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        // vertical / gravity & jump
        if (cc.isGrounded && velocity.y < 0f)
            velocity.y = -2f; // small ground stick

        if (Input.GetButtonDown("Jump") && cc.isGrounded && jumpHeight > 0f)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;

        // apply movement
        Vector3 finalVelocity = (moveVelocity) + new Vector3(0, velocity.y, 0);
        cc.Move(finalVelocity * Time.deltaTime);
    }
}
