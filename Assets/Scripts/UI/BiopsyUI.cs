using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BiopsyUI : UIObject
{
    public BiopsyManager manager;
    public TextMeshPro label;

    public override void UpdateInterface()
    {
        base.UpdateInterface();
        if (Program.instance.interactionManager.currentPhase == Phase.close)
        {
            enabled = true;

            label.text = Math.Round(
                manager.biopsyTool.DistanceFromTumor() / 10,
                2
            ).ToString() + " cm";
        }
        else
        {
            enabled = false;
        }
    }
}
