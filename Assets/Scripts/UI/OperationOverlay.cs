using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OperationOverlayStyle
{
    skinned,
    compound,
    mesh,
    mri
}

public class OperationOverlay : MonoBehaviour
{
    public OperationOverlayStyle currentStyle;
    public Head head;
    public Tumor tumor;

    public float alpha;

    public void SetAlpha(float newAlpha)
    {
        alpha = newAlpha;
        head.materialInside.color = new Color(0.7f, 0.7f, 0.7f, alpha);
    }

    public void Update()
    {
        
        if(Program.instance.biopsyManager.biopsyTool.CloseToEntryPoint())
        {
            currentStyle = OperationOverlayStyle.mesh;
        }
        else
        {
            currentStyle = OperationOverlayStyle.skinned;
        }

    }

}
