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
        if (manager.biopsyTool.CloseToEntryPoint())
        {
            enabled = true;

            base.UpdateInterface();

            label.text = Math.Round(
                manager.biopsyTool.DistanceFromTumor(),
                2
            ).ToString() + " cm";
        }
        else
        {
            enabled = false;
        }
    }
}
