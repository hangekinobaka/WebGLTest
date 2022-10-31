using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Transform platform;
    public float speed = .4f;

    private Rigidbody platformRb;

    private Vector3 anchorPos;
    private Vector3 targetPos;
    private Vector3 tarRot;
    private void Awake()
    {
        platformRb = platform.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        // mouse click - always
        if (Input.GetMouseButton(0))
        {
            //  mouse click - the first frames
            if (Input.GetMouseButtonDown(0))
            {
                anchorPos = Input.mousePosition;
            }
            targetPos = Input.mousePosition;

        }

        if (Vector3.Distance(targetPos, anchorPos) > 5)
        {
            Vector3 delta = (targetPos - anchorPos) * speed;
            anchorPos += delta * Time.deltaTime;
            tarRot = new Vector3(delta.y, 0, -delta.x);
        }
        else
        {
            targetPos = anchorPos;
        }

    }
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(tarRot * Time.fixedDeltaTime);
        platformRb.MoveRotation(platformRb.rotation * deltaRotation);
    }
}
