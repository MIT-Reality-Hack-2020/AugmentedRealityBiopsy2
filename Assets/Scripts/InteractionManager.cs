using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Camera mainCamera;
    public AROverlay overlay;
    public PatientID patientID;

    public float DistanceFromCamera(Vector3 checkPosition)
    {
        return Vector3.Distance(
            mainCamera.transform.position,
            overlay.transform.position
        );
    }

    public void Update()
    {
        UpdatePatientID();
    }

    public void UpdatePatientID()
    {
        if (DistanceFromCamera(overlay.transform.position) > 0.5f)
        {
            patientID.enabled = false;
        }
        else
        {
            patientID.enabled = true;
        }
    }
}
