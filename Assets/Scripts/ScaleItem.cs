using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectItem;

public class ScaleItem : MonoBehaviour
{

    public GameObject leftController;
    public GameObject rightController;
    public static Vector3 startPosLeft;
    public static Vector3 startPosRight;
    public static float startDistanceBetween;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPosLeft = leftController.transform.position;
        Vector3 currPosRight = rightController.transform.position;
        float distanceBetween = (currPosLeft - currPosRight).magnitude;
        if (SelectItem.selectedItem != null) {
            if (distanceBetween - 0.1f > startDistanceBetween && SelectItem.selectedItem.transform.localScale.x + 0.005f < 10.0f)
            {
                SelectItem.selectedItem.transform.localScale = new Vector3(SelectItem.selectedItem.transform.localScale.x + 0.005f,
                                                                            SelectItem.selectedItem.transform.localScale.y + 0.005f,
                                                                            SelectItem.selectedItem.transform.localScale.z + 0.005f);
            } else if (distanceBetween + 0.1f < startDistanceBetween && SelectItem.selectedItem.transform.localScale.x - 0.005f > 0) {
                SelectItem.selectedItem.transform.localScale = new Vector3(SelectItem.selectedItem.transform.localScale.x - 0.005f,
                                                                            SelectItem.selectedItem.transform.localScale.y - 0.005f,
                                                                            SelectItem.selectedItem.transform.localScale.z - 0.005f);
            }
        }
        
    }
}
