using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{

    public Camera cam;
    Vector3 cameraDirection;
    public float cameraDistance;
    Vector2 cameraDistanceMinMax = new Vector2(0.5f, 5f);

    void Start()
    {
        cameraDirection = transform.localPosition.normalized;
        cameraDistance = cameraDistanceMinMax.y;
    }

    void Update()
    {
        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * 3);
        RaycastHit hit;
        if(Physics.Linecast(transform.position, desiredCameraPosition, out hit))
        {
            cameraDistance = Mathf.Clamp(hit.distance * 0.9f, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
        }
        else
        {
            cameraDistance = cameraDistanceMinMax.y;
        }
        cam.transform.localPosition = cameraDirection * cameraDistance;
    }
}
