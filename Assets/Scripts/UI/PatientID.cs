using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientID : UIObject
{
    public InteractionManager manager;
    public AROverlay overlay;

    public bool approved;

    public void Approve()
    {
        approved = true;
    }

    public void Dismiss()
    {

    }

    public override void UpdateInterface()
    {
        if (approved)
        {
            enabled = false;
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
