using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 3;
    [SerializeField] float turnSmoothSpeed = 0.1f;
    [SerializeField] Transform cam;
    [SerializeField] Animator animator;
    float turnSmoothVel;
    PlayerControls controls;
    [SerializeField] GameObject theRig;

    private void Awake() {
        controls = new PlayerControls();
    }
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 direction = new Vector3(hor, 0, ver).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = 10;
        }
        if (direction.magnitude >= 0.1) {

            if (speed == 3) {
                animator.Play("WalkAnimation");
            }
            if (speed == 10) {
                animator.Play("RunAnimation");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                // animator.Play("WalkAnimation");
                speed = 3;
            }


            // this is responsible for making the player move, and rotate towards the direction its moving 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothenedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothSpeed);
            transform.rotation = Quaternion.Euler(0f, smoothenedAngle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(movDir * speed * Time.deltaTime);

            // rb.AddForce(movDir, ForceMode.VelocityChange);
        }
        if (direction.magnitude == 0) {
            animator.Play("IdleAnimation");
        }
        if (Input.GetKeyDown(KeyCode.Space) && direction.magnitude == 0) {
            animator.Play("JumpAnimation");
        }
    }
    private void FixedUpdate() {
        if (controller.isGrounded == false) {
            // movDir += Physics.gravity;
            controller.Move(new Vector3(0, -0.22f, 0));
        }
        if (speed == 0) {
            Invoke("RagdollOff", 3);
        }
    }

}
