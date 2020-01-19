using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OverlayStyle
{
    skinned,
    compound,
    mesh,
    mri
}

public class AROverlay : MonoBehaviour
{
    public OverlayStyle currentStyle;
    public Head head;
    public Tumor tumor;
    public GameObject orientationSphere;

    public void Update()
    {
        
        if(Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
        {
            currentStyle = OverlayStyle.mesh;
        }
        else
        {
            currentStyle = OverlayStyle.skinned;
        }

    }

}
