using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float followDistance;
    public float cameraFollowSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        transform.position = targetPosition + followVector;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector;

        if (Input.GetKey(KeyCode.A))
        { 
            gameObject.transform.RotateAround(target.transform.position, Vector3.up, target.transform.eulerAngles.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.RotateAround(target.transform.position, Vector3.up, -target.transform.eulerAngles.y);
        }

        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, cameraFollowSpeed * Time.deltaTime);


    }
}
