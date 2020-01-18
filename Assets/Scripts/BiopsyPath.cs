using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyPath : MonoBehaviour
{
    public BiopsyManager manager;
    public LineRenderer lineRenderer;
    public SurgicalPointBiopsy biopsyPoint;
    public SurgicalPointEntry entryPoint;

    public Material matRegular;
    public Material matCorrent;
    public Material matFalse;

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdateAppearance();
    }

    public bool ToolInReach()
    {
        return false;
    }

    public bool CorrectAngle()
    {
        return false;
    }


    public void UpdatePosition()
    {
        if(biopsyPoint && entryPoint)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, biopsyPoint.transform.position);
            lineRenderer.SetPosition(1, entryPoint.transform.position);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }

    public void UpdateAppearance()
    {
        if(!ToolInReach())
        {
            // regular

        }
        else if(ToolInReach() && CorrectAngle())
        {
            //green
        }
        else if(ToolInReach() && !CorrectAngle())
        {
            //red
        }
    }
}
