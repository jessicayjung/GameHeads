using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Move : MonoBehaviour
{
   public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentSpeed = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.RotateAround(transform.position, Vector3.up, -speed.y * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.RotateAround(transform.position, Vector3.up, speed.y * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed.z = speed.z; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed.z = -speed.z;
        }
        gameObject.transform.Translate(currentSpeed * Time.deltaTime);
    }
}
