using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BiopsyUI : UIObject
{
    public OperationOverlay operationOverlay;
    public BiopsyManager manager;
    public TextMeshPro description;
    public TextMeshPro valueLabel;

    public override void UpdateInterface()
    {
        if(manager.biopsyCollected)
        {
            enabled = true;
            description.enabled = false;
            valueLabel.text = "Biopsy Collected";
            
            base.UpdateInterface();
        }
        else if(operationOverlay.IsVisible() && manager.biopsyPath.CurrentCorrectness() != Correctness.correct)
        {
            enabled = true;
            description.enabled = false;
            valueLabel.text = "Adjust Instrument";
            
            base.UpdateInterface();
        }
        else if (operationOverlay.IsVisible() && manager.biopsyPath.CurrentCorrectness() == Correctness.correct)
        {
            enabled = true;
            description.enabled = true;
            
            base.UpdateInterface();

            valueLabel.text = Math.Round(
                manager.biopsyTool.DistanceFromTumor(),
                2
            ).ToString() + " cm" 
            + System.Environment.NewLine 
            + manager.biopsyPath.BiopsyAngle();
        }
        else
        {
            enabled = false;
        }
    }
}
