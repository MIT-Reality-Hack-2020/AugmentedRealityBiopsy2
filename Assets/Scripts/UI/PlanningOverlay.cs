using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanningOverlay : UIObject
{
    public bool planned;


    public void Plan()
    {
        planned = true;
    }
    
    public bool IsVisible()
    {
        return Program.instance.startOverlay.launched
        && Program.instance.patientID.approved
        && !Program.instance.planningOverlay.planned;
    }

    public override void UpdateInterface()
    {
        if(IsVisible()) 
        {
            base.UpdateInterface();
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }

}
