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

    public bool CorrectAngle()
    {
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVisible() && biopsyPoint && entryPoint)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, biopsyPoint.transform.position);
            lineRenderer.SetPosition(1, entryPoint.transform.position);

            lineRenderer.material = matRegular;

            if (!biopsyManager.ToolInReach())
            {
                // regular
            }
            else{
                
            }
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }

}
