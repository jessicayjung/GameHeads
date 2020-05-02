using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed; //Amount of units to move per second

    //Amount of degrees per second to turn
    public float turnSpeed;
    public float jumpForce;
    private bool isJumping = false;
    private bool isGrounded;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 currentSpeed = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed.x = -speed.x; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed.x = speed.x;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed.z = speed.z;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed.z = -speed.z;
        }
        //Speed is a Vector3 defines how fast to move in 3D space
        gameObject.transform.Translate(currentSpeed * Time.deltaTime);
    }*/

    void Update()
    {
       
    }

    //anything to do with physics should be in Fixed Update
    void FixedUpdate()
    {
        float currentSpeed = 0.0f;
        float currentTurnAmount = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            currentTurnAmount -= turnSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentTurnAmount += turnSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = speed.x;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = -speed.x;
        }

        //Speed is a Vector3 defines how fast to move in 3D space
        gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime, ForceMode.Impulse);
        
        if (Input.GetKeyUp(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        


        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("isGrounded is true");
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("isGrounded is false");
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
