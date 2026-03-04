using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetVaso : MonoBehaviour
{
    public Transform trackerVaso;
    
    [Header("Offset Manual")]
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    void LateUpdate()
    {
        if (trackerVaso == null) return;

        // Posición con offset relativo al tracker
        transform.position = trackerVaso.position + trackerVaso.TransformDirection(positionOffset);
        Quaternion offsetRotation = Quaternion.Euler(rotationOffset);
        transform.rotation = trackerVaso.rotation * offsetRotation;
    }
}
