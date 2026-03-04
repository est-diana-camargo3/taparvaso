using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetTapa : MonoBehaviour
{
    public Transform trackerTapa;
    
    [Header("Offset Manual")]
    public Vector3 positionOffset;

    void LateUpdate()
    {
        if (trackerTapa == null) return;

        // Posición con offset relativo al tracker
        transform.position = trackerTapa.position + trackerTapa.TransformDirection(positionOffset);
        transform.rotation = trackerTapa.rotation;
    }
}
