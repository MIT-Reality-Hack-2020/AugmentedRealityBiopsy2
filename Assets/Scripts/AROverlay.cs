using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OverlayStyle
{
    skinned,
    compound,
    mesh,
    mri
}

public class AROverlay : MonoBehaviour
{
    public OverlayStyle currentStyle;
    public Head head;
    public Tumor tumor;
    public GameObject orientationSphere;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Program.instance.biopsyManager.biopsyTool.RightIndexFinger()
            && Program.instance.biopsyManager.biopsyTool.Wrist())
            {

                Vector3 rightIndexFinger = Program.instance.biopsyManager.biopsyTool.RightIndexFinger().transform.position;
                Vector3 wrist = Program.instance.biopsyManager.biopsyTool.Wrist().transform.position;

                orientationSphere.transform.position = rightIndexFinger;

                orientationSphere.transform.LookAt(Camera.main.transform);

                float yaw = orientationSphere.transform.rotation.y;

                orientationSphere.transform.rotation = Quaternion.Euler(
                    0f,
                    yaw,
                    0f
                );
            }

        }

    }

}
