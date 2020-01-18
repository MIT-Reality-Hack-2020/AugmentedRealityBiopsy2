using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OverlayStyle{
    skinned,
    compound,
    mesh,
    mri
}

public class AROverlay : MonoBehaviour
{
    public OverlayStyle currentStyle;
    public Head head;

}
