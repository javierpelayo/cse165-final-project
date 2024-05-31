using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRay : MonoBehaviour
{
    public LineRenderer lr;
    public float rayLength = 10.0f;

    public LayerMask interactableLayers;
    public Camera mainCamera;
    public GameObject mainCanvas;

    public static Vector3 rayStartPosition;
    public static Vector3 rayEndPosition;
    public static RaycastHit isectInfo;
    public static bool rayHitsCollider;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector3 endPosition = new Vector3(transform.position.x + transform.forward.x * rayLength, transform.position.y + transform.forward.y * rayLength, transform.position.z + transform.forward.z * rayLength);

        rayHitsCollider = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);
        isectInfo = hit;

        if (rayHitsCollider) {
            endPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        //Debug.Log("Controller: transform position: " + transform.position + ", transform forward:" + transform.forward);
        //Debug.Log("Main Camera: transform position: " + mainCamera.transform.position + ", transform forward:" + mainCamera.transform.forward);

        lr.SetPosition(0, transform.position); // start
        lr.SetPosition(1, endPosition); // end
        rayEndPosition = endPosition;
        rayStartPosition = transform.position;
    }

    // public GameObject GetHitObject()
    // {
    //     if (rayHitsCollider)
    //     {
    //         return isectInfo.collider.gameObject;
    //     }
    //     return null;
    // }
}
