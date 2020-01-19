using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientID : UIObject
{
    public bool approved;

    public void Approve()
    {
        approved = true;
    }

    public void Dismiss()
    {

    }

    public bool IsVisible()
    {
        return !approved;
    }

    public override void UpdateInterface()
    {
        if (IsVisible())
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
