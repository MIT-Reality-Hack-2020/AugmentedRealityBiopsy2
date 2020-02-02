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

public class OperationOverlay : UIObject
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
        if(Program.instance.currentMode == ProgramMode.mriExploration)
            return true;
        else
            return  Program.instance.startOverlay && Program.instance.startOverlay.launched
            && Program.instance.patientID && Program.instance.patientID.approved
            && Program.instance.planningOverlay && Program.instance.planningOverlay.planned
            && Program.instance.biopsyManager && Program.instance.biopsyManager.currentPhase != BiopsyPhase.analyzing;
    }


    public override void UpdateInterface()
    {
        if (IsVisible())
        {
            base.UpdateInterface();
            enabled = true;

            if (Program.instance.biopsyManager && Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
            {
                currentStyle = OperationOverlayStyle.compound;
            }
            else if(Program.instance.biopsyManager && !Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
            {
                currentStyle = OperationOverlayStyle.skinned;
            }
        }
        else
        {
            enabled = false;
        }

    }

}
