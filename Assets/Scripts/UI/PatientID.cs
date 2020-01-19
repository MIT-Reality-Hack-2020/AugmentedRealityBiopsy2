using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientID : UIObject
{
    public InteractionManager manager;
    public AROverlay overlay;

    public bool outOfTheWay;

    public override void UpdateInterface()
    {
        // if (manager.currentPhase == Phase.far)
        // {
        //     enabled = false;
        // }
        // else if (manager.currentPhase == Phase.identification)
        // {
        //     base.UpdateInterface();

        //     enabled = true;
        //     outOfTheWay = false;
        // }
        // else 
        if (Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
        {
            base.UpdateInterface();
            enabled = false;
            //outOfTheWay = true;
        }
        else
        {
            base.UpdateInterface();
            enabled = true;
        }
    }


    // public IEnumerator FadeIn()
    // {

    // }

    // public IEnumerator FadeOut()
    // {

    // }
}
