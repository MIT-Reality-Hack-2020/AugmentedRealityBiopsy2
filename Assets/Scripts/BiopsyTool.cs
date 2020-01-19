using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyTool : MonoBehaviour
{
    public BiopsyManager manager;
    public LineRenderer rod;
    public LineRenderer coloredTip;

    public GameObject fakeFingerFront;

    public GameObject fakeFingerBack;

    public Vector3 toolTip;

    public bool biopsyRunning;

    public float lengthOfTool = 0.2f;

    public GameObject RightIndexFinger()
    {
        return GameObject.Find("Right_PokePointer(Clone)");
    }

    public GameObject Wrist()
    {
        GameObject rightHand = GameObject.Find("Right_HandRight(Clone)");
        if (rightHand)
            return rightHand.transform.Find("Wrist Proxy Transform").gameObject;
        else
        {
            return null;
        }
    }

    public float DistanceFromTumor()
    {
        return Vector3.Distance(
            Program.instance.aROverlay.tumor.transform.position,
            toolTip
        );
    }


    public bool CloseToEntryPoint()
    {
        if (RightIndexFinger()
        && Vector3.Distance(
            manager.entryPoint.transform.position,
            toolTip
        ) < 0.15f
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 ToolVector(GameObject frontObject, GameObject backObject)
    {
        return (frontObject.transform.position - backObject.transform.position).normalized;
    }

    public void Update()
    {
        GameObject indexFingerKnuckle = GameObject.Find("IndexKnuckle Proxy Transform");

        if (RightIndexFinger() && indexFingerKnuckle
        && Program.instance.interactionManager.currentPhase == Phase.close)
        {
            biopsyRunning = true;

            toolTip = RightIndexFinger().transform.position + ToolVector(RightIndexFinger(), indexFingerKnuckle) * lengthOfTool;

            Vector3 endOfTool = RightIndexFinger().transform.position + -ToolVector(RightIndexFinger(), indexFingerKnuckle) * lengthOfTool;

            rod.positionCount = 2;
            rod.SetPosition(0, toolTip);
            rod.SetPosition(1, endOfTool);

            float remainingDistance = Vector3.Distance(
                Program.instance.aROverlay.tumor.transform.position,
                toolTip
            );

            coloredTip.positionCount = 2;
            coloredTip.SetPosition(0, toolTip);
            coloredTip.SetPosition(
                1,
                toolTip + -ToolVector(RightIndexFinger(), indexFingerKnuckle) * remainingDistance // fakefinger
            );

            this.transform.position = RightIndexFinger().transform.position;
        }
        else
        {
            biopsyRunning = false;
            rod.positionCount = 0;
            coloredTip.positionCount = 0;
            toolTip = Vector3.zero;
        }

    }
}
