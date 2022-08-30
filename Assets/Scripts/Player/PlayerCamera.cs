using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5;
    [SerializeField]
    private float rotCamYAxisSpeed = 3;

    private float RotateMinX = -80;
    private float RotateMaxX = 50;
    [HideInInspector] public float eulerAngleX;
    [HideInInspector] public float eulerAngleY;

   

    public void UpdateRotate(float mouseX,float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;
        eulerAngleX -= mouseY * rotCamXAxisSpeed;
        eulerAngleX = ClampAngle(eulerAngleX, RotateMinX, RotateMaxX);
        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }
    
    private float ClampAngle(float angle,float min,float Max)
    {
        if (angle < - 360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, Max);

    }
}
