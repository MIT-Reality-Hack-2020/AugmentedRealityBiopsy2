using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyTool : MonoBehaviour
{
    public BiopsyManager manager;
    public LineRenderer rod;
    public LineRenderer coloredTip;

    public Vector3 toolTip;

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

    public void Update()
    {
        //GameObject pointer = GameObject.Find("Right_DefaultControllerPointer(Clone)");
        GameObject thumbTipGO = GameObject.Find("ThumbTip Proxy Transform");


        if (Wrist() && RightIndexFinger() && thumbTipGO
        && Program.instance.interactionManager.currentPhase == Phase.close)
        {

            Vector3 thumbTip = thumbTipGO.transform.position;

            Vector3 uprightVector = (Wrist().transform.position - RightIndexFinger().transform.position);

            Vector3 toolVector = Vector3.Cross(
                uprightVector,
                RightIndexFinger().transform.position - thumbTip
            );

            
            toolTip = thumbTip + toolVector * 0.2f;

            rod.positionCount = 2;
            //rod.SetPosition(0, wrist.transform.position);
            rod.SetPosition(0, toolTip);
            rod.SetPosition(1, thumbTip - toolVector * 0.2f);


            float remainingDistance = Vector3.Distance(
                Program.instance.aROverlay.tumor.transform.position,
                toolTip
            );

            coloredTip.positionCount = 2;
            coloredTip.SetPosition(0, toolTip);
            coloredTip.SetPosition(
                1, 
                manager.entryPoint.transform.position + toolVector * remainingDistance
            );
        }
        else
        {
            rod.positionCount = 0;
            coloredTip.positionCount = 0;
            toolTip = Vector3.zero;
        }

    }
}
