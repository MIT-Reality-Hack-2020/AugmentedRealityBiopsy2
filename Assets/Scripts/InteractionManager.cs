﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Phase
{
    far, // you see nothing
    close, // entrypoint
}


public class InteractionManager : MonoBehaviour
{
    public Phase currentPhase;
    public Camera mainCamera;
    public PatientID patientID;

    public float DistanceFromCamera(Vector3 checkPosition)
    {
        return Vector3.Distance(
            mainCamera.transform.position,
            checkPosition
        );
    }

    public float DistanceFromCamera()
    {
        return Vector3.Distance(
            mainCamera.transform.position,
            Program.instance.operationOverlay.transform.position
        );
    }

    public void Update()
    {
        if(DistanceFromCamera() > 1.8f && patientID)
        {
            UI.instance.patientID.approved = false;
        }
        else if(DistanceFromCamera() > 1.1f )
        {
            currentPhase = Phase.far;
        }
        else if(DistanceFromCamera() <= 1.1f)
        {
            currentPhase = Phase.close;
        }
    }

}
