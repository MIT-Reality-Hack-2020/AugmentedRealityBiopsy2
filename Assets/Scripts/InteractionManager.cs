using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Phase
{
    far, // you see nothing
    identification,  /// skinned model, patient ID, checklist, 
    close, // entrypoint
}


public class InteractionManager : MonoBehaviour
{
    public Phase currentPhase;

    public Camera mainCamera;
    public AROverlay overlay;
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
            overlay.transform.position
        );
    }

    public void Update()
    {
        if(DistanceFromCamera() > 1f )
        {
            currentPhase = Phase.far;
        }
        else if(DistanceFromCamera() <= 1f && DistanceFromCamera() > 0.5f)
        {
            currentPhase = Phase.identification;
        }
        else if(DistanceFromCamera() < 0.5f)
        {
            currentPhase = Phase.close;  
        }

        if(DistanceFromCamera() > 0.6f)
        {
            Program.instance.aROverlay.currentStyle = OverlayStyle.skinned;
        }
        else
        {
            Program.instance.aROverlay.currentStyle = OverlayStyle.mesh;
        }
    }

}
