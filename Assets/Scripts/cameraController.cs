using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public bool battleTime;
    public GameObject battleCameraPos;

    private void Start()
    {
        targetOffset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        if (!battleTime)
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, .125f);
        else
            transform.position = Vector3.Lerp(transform.position, battleCameraPos.transform.position, .025f);
    }
}
