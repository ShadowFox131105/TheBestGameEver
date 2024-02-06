using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float RotationSpeed = 1f;
    public float RotationSpeedY = 1f;
    public float minAngle; 
    public float maxAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x + Time.deltaTime * RotationSpeedY * -Input.GetAxis("Mouse Y");
        
        if (newAngleX > 180)
        {
            newAngleX -= 360;
        }

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);



        CameraAxisTransform.localEulerAngles = new Vector3 (newAngleX, 0,0);
    }
}
