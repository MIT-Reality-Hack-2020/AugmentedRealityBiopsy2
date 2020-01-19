using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OperationOverlayStyle
{
    skinned,
    compound,
    mesh,
    mri
}

public class OperationOverlay : MonoBehaviour
{
    public OperationOverlayStyle currentStyle;
    public HeadOperation head;
    public float alpha;

    public void SetAlpha(float newAlpha)
    {
        alpha = newAlpha;
        head.materialInside.color = new Color(0.7f, 0.7f, 0.7f, alpha);
    }
    
    public bool IsVisible()
    {
        return Program.instance.interactionManager.currentPhase == Phase.close 
        && Program.instance.planningOverlay.planned
        && Program.instance.patientID.approved;
    }


    public void Update()
    {
        
        if(Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
        {
            currentStyle = OperationOverlayStyle.mesh;
        }
        else
        {
            currentStyle = OperationOverlayStyle.skinned;
        }
    }

}
