using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour {
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private CharacterController controller;
    private Vector3 velocity;
    public Camera playerCam;

    void Start() {
        controller = GetComponent<CharacterController>();
        if (!isLocalPlayer) {
            playerCam.enabled = false;
            playerCam.GetComponent<AudioListener>().enabled = false;
        }
    }

    void Update() {
        if (!isLocalPlayer) return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
