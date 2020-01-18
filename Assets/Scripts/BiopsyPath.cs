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

    public bool CorrectAngle()
    {
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionManager.currentPhase == Phase.close && biopsyPoint && entryPoint)
        {
            lineRenderer.positionCount = 3;
            lineRenderer.SetPosition(0, biopsyPoint.transform.position);
            lineRenderer.SetPosition(1, entryPoint.transform.position);
            lineRenderer.SetPosition(2, biopsyPoint.transform.position + (entryPoint.transform.position - biopsyPoint.transform.position)*2f);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }

}
