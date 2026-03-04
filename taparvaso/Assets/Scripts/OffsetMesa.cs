using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMesa : MonoBehaviour
{
    public Transform trackerMesa;
    
    [Header("Offset Manual")]
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    void LateUpdate()
    {
        if (trackerMesa == null) return;

        // Posición con offset relativo al tracker
        transform.position = trackerMesa.position + trackerMesa.TransformDirection(positionOffset);
        Quaternion offsetRotation = Quaternion.Euler(rotationOffset);
        transform.rotation = trackerMesa.rotation * offsetRotation;
    }
}
