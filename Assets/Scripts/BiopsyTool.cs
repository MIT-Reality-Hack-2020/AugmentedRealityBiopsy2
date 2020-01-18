using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyTool : MonoBehaviour
{
    public BiopsyManager manager;

    public GameObject front;
    public GameObject back;
    public BiopsyToolExtension extension;

    public LineRenderer rod;

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
    public void Update()
    {

        //GameObject pointer = GameObject.Find("Right_DefaultControllerPointer(Clone)");

        if (Wrist() && RightIndexFinger() && manager.ToolInReach())
        {
            rod.positionCount = 3;
            //rod.SetPosition(0, wrist.transform.position);
            rod.SetPosition(0, Wrist().transform.position);
            rod.SetPosition(1, RightIndexFinger().transform.position);
            rod.SetPosition(2, (RightIndexFinger().transform.position - Wrist().transform.position));
        }
        else
        {
            rod.positionCount = 0;
        }

    }
}
