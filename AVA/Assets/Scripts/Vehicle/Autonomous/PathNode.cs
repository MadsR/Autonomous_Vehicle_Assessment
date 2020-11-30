﻿using UnityEngine;

public class PathNode : MonoBehaviour
{
    public float targetVelocity;
    public bool activeNode;
    static LayerMask layerMask = ~13;
    public float targetHeight = 1;
    private float deltaHeight;
    public SpeedType speedType;

    public void SetHeight()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 250, layerMask))
        {
            deltaHeight = targetHeight + transform.InverseTransformPoint(hit.point).y;

            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + deltaHeight, transform.position.z);
            transform.position = newPos;

            //Gizmos.DrawLine(transform.position, hit.point);
        }
    }

    public void RecalculateSpeed()
    {
        targetVelocity = targetVelocity * GenericFunctions.SpeedCoefficient(speedType);
    }

    public void WaypointEvent()
    {

    }
}
