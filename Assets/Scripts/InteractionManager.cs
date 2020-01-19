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
        if(DistanceFromCamera() > 1.1f )
        {
            currentPhase = Phase.far;
        }
        else if(DistanceFromCamera() <= 1.1f && DistanceFromCamera() > 0.65f)
        {
            currentPhase = Phase.identification;
        }
        else if(DistanceFromCamera() < 0.65f)
        {
            currentPhase = Phase.close;  
        }

        if(Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
        {
            Program.instance.aROverlay.currentStyle = OverlayStyle.mesh;
        }
        else
        {
            Program.instance.aROverlay.currentStyle = OverlayStyle.skinned;
        }
    }

}
