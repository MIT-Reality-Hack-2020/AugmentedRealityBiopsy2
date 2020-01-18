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
        base.UpdateInterface();
        if (manager.currentPhase == Phase.far)
        {
            enabled = false;
        }
        else if (manager.currentPhase == Phase.identification)
        {
            enabled = true;
            outOfTheWay = false;
        }
        else if (manager.currentPhase == Phase.close)
        {
            enabled = true;
            outOfTheWay = true;
        }
    }


    // public IEnumerator FadeIn()
    // {

    // }

    // public IEnumerator FadeOut()
    // {

    // }
}
