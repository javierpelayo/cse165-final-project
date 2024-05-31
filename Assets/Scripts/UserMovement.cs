using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class UserMovement : MonoBehaviour
{

    // Start is called before the first frame update

    public float speed = 2.0f;
    public Transform cameraTransform;


    // Update is called once per frame
    void Update()
    {
        Vector2 joystickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 move = new Vector3(joystickInput.x, 0, joystickInput.y);
        move = cameraTransform.TransformDirection(move);
        move.y = 0;
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }


}
