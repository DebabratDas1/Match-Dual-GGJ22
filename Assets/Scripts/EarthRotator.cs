using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotator : MonoBehaviour
{
    [SerializeField] private float rotatorSpeed = 100f;
    //bool dragging = false;
    //Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }*/

    }

    private void FixedUpdate()
    {
        /*if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;
            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);

        }*/
    }
    private void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.deltaTime * Mathf.Deg2Rad * 9999;
        float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.deltaTime * Mathf.Deg2Rad * 9999;

        transform.Rotate(transform.up, -x);
        transform.Rotate(transform.right, -y);

    }
}
