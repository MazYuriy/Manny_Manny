using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform Player;
    float xRot ;
    float yRot ;
    void Start()
    {

    }

    void Update()
    {
        float mousX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mousY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRot -= mousY;  
        yRot = Mathf.Clamp(yRot, -90f, 90f);

        Player.Rotate(Vector3.up * mousX);

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
    }
}