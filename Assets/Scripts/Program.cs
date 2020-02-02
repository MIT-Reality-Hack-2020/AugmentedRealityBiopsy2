﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProgramMode 
{
    simulation,
    mriExploration
}

public class Program : MonoBehaviour
{
    public static Program instance;
    public ProgramMode currentMode;
    public ImportManager importManager;
    
    public InteractionManager interactionManager;
    
    public TransferFunctionManager transferFunctionManager;
    public BiopsyManager biopsyManager;

    public TransferFunctionUI transferFunctionUI;

    public StartOverlay startOverlay;
    public PatientID patientID;
    public BiopsyUI biopsyUI;
    public PlanningOverlay planningOverlay;
    
    public VolumeRenderedObject volumeRenderedObject;
    public OperationOverlay operationOverlay;
    public FinalOverlay finalOverlay;


    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        UpdateOverlays();
    }

    public void UpdateOverlays()
    {
        if(startOverlay)
            startOverlay.UpdateInterface();

        if(operationOverlay)
            operationOverlay.UpdateInterface();

        if(patientID)
            patientID.UpdateInterface();

        if(biopsyUI)
            biopsyUI.UpdateInterface();

        if(planningOverlay)    
            planningOverlay.UpdateInterface();
        
        if(finalOverlay)
            finalOverlay.UpdateInterface();
        // if(alphaSlider)
        //     alphaSlider.UpdateInterface();
    }
}
