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
            currentStyle = OverlayStyle.mesh;
        }
        else
        {
            currentStyle = OverlayStyle.skinned;
        }

    }

}
