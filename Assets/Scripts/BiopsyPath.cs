using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Correctness
{
    off,
    intermediate,
    correct
}

public class BiopsyPath : MonoBehaviour
{
    public BiopsyManager biopsyManager;
    public InteractionManager interactionManager;
    public LineRenderer lineRenderer;
    public SurgicalPointEntry entryPoint;

    public Material materialNormal;
    public Material materialCorrect;
    public Material materialIntermediate;
    public Material materialFalse;

    public Correctness CurrentCorrectness()
    {
        if(Vector3.Angle(
            biopsyManager.biopsyTool.ToolVector(),
            TrajectoryVector()
        ) < 5f 
        && Vector3.Angle(
            biopsyManager.biopsyTool.ToolVector(),
            TrajectoryVector()
        ) > 175f)
        {
            return Correctness.correct;
        }
        else if(Vector3.Angle(
            biopsyManager.biopsyTool.ToolVector(),
            TrajectoryVector()
        ) < 10f 
        && Vector3.Angle(
            biopsyManager.biopsyTool.ToolVector(),
            TrajectoryVector()
        ) > 170f)
        {
            return Correctness.intermediate;
        }
        else
        {
            return Correctness.off;
        }
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

            if(biopsyManager.biopsyTool.VeryCloseToEntryPoint() && CurrentCorrectness() == Correctness.correct)
            {
                lineRenderer.material = materialCorrect;
            }
            else if(biopsyManager.biopsyTool.VeryCloseToEntryPoint() && CurrentCorrectness() == Correctness.intermediate)
            {
                lineRenderer.material = materialIntermediate;
            }
            else if(biopsyManager.biopsyTool.VeryCloseToEntryPoint() && CurrentCorrectness() == Correctness.off)
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
