using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float sensetive = 100f;
    public Transform Player;
    float xRot = 0f;
    float yRot = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mousX = Input.GetAxis("Mouse X") * sensetive * Time.deltaTime;
        float mousY = Input.GetAxis("Mouse Y") * sensetive * Time.deltaTime;

        xRot -= mousY;
        xRot = Mathf.Clamp(xRot, -50f, 30f);


        Player.Rotate(Vector3.up * mousX);
        yRot = 0f;


        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
    }
}