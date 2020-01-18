using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BiopsyManager : MonoBehaviour
{
    public BiopsyTool biopsyTool;
    
    public BiopsyPath biopsyPath;

    public SurgicalPointEntry entryPoint;

    public SurgicalPointBiopsy biopsyPoint1;
    public SurgicalPointBiopsy biopsyPoint2;
    public SurgicalPointBiopsy biopsyPoint3;
    public SurgicalPointBiopsy biopsyPoint4;

    public bool ToolInReach()
    {
        return Vector3.Distance(
            biopsyTool.RightIndexFinger().transform.position,
            entryPoint.transform.position) < 0.1f;
    }
}
