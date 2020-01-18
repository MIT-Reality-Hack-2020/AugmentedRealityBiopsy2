using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyPath : MonoBehaviour
{
    public BiopsyManager biopsyManager;
    public InteractionManager interactionManager;
    public LineRenderer lineRenderer;
    public SurgicalPointBiopsy biopsyPoint;
    public SurgicalPointEntry entryPoint;

    public Material matRegular;
    public Material matCorrent;
    public Material matFalse;

    float interactionThreshold = 0.4f;

    public bool IsVisible()
    {
        return interactionManager.DistanceFromCamera() < interactionThreshold;
    }

    public bool ToolInReach()
    {
        return false;
    }

    public bool CorrectAngle()
    {
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVisible() && biopsyPoint && entryPoint)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, biopsyPoint.transform.position);
            lineRenderer.SetPosition(1, entryPoint.transform.position);

            if (!ToolInReach())
            {
                // regular
                lineRenderer.material = matRegular;
            }
            else if (interactionManager.DistanceFromCamera() < 0.2f &&
                ToolInReach() && CorrectAngle())
            {
                //green
            }
            else if (ToolInReach() && !CorrectAngle())
            {
                //red
            }
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }

}
