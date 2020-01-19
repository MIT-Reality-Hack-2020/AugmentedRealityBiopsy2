using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;
    public TransferFunctionUI transferFunctionUI;
    public PatientID patientID;
    public BiopsyUI biopsyUI;
    public AlphaSlider alphaSlider;

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        patientID.UpdateInterface();
        biopsyUI.UpdateInterface();

        if(alphaSlider)
            alphaSlider.UpdateInterface();
    }
}
