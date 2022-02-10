using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotation : MonoBehaviour
{
    [SerializeField] private GameObject groundPlane;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask otherMask;
    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        if(mousePos != Input.mousePosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
            {
                mousePos = Input.mousePosition;

                hit.point = new Vector3(hit.point.x, 
                    hit.point.y + transform.position.y, hit.point.z);
                transform.rotation = Quaternion.LookRotation(hit.point - transform.position);

                //Debug.Log(hit.point.y + transform.position.y - groudnPlane.transform.position.y - (transform.localScale.y / 2));
            }
        }
        
    }
}
