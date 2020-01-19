using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyPath : MonoBehaviour
{
    public BiopsyManager biopsyManager;
    public InteractionManager interactionManager;
    public LineRenderer lineRenderer;
    public SurgicalPointEntry entryPoint;

    public Material materialNormal;
    public Material materialCorrect;
    public Material materialFalse;

    public bool CorrectAngle()
    {
        return Vector3.Angle(
            biopsyManager.biopsyTool.ToolVector(),
            TrajectoryVector()
        ) < 5f 
        && Vector3.Angle(
            biopsyManager.biopsyTool.ToolVector(),
            TrajectoryVector()
        ) > 175f ;
    }

    public Vector3 TrajectoryVector()
    {
        return (entryPoint.transform.position - biopsyManager.biopsyPoint.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionManager.currentPhase == Phase.close && entryPoint)
        {
            lineRenderer.positionCount = 3;
            lineRenderer.SetPosition(0, biopsyManager.biopsyPoint.transform.position);
            lineRenderer.SetPosition(1, entryPoint.transform.position);
            lineRenderer.SetPosition(2, biopsyManager.biopsyPoint.transform.position + TrajectoryVector()*0.2f);

            if(biopsyManager.biopsyTool.VeryCloseToEntryPoint() && CorrectAngle())
            {
                lineRenderer.material = materialCorrect;
            }
            else if(biopsyManager.biopsyTool.VeryCloseToEntryPoint() && !CorrectAngle())
            {
                lineRenderer.material = materialFalse;
            }
            else
            {
                lineRenderer.material = materialNormal;
            }

        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }

}
