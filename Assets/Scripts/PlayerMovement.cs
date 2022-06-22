using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 10f; 
    [SerializeField] Transform groundCheck;   
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }
    }

    void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy Head")) {
            Destroy(collision.transform.parent.gameObject); // destroy the enemy
            Jump();
        } else if (collision.gameObject.CompareTag("Finish Line")) {
            FinishLevel();
        }
    }

    void FinishLevel() {
        Debug.Log("Level Finished");
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
