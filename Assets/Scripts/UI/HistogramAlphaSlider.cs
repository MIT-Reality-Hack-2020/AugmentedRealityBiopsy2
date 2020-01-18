using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class HistogramAlphaSlider : PinchSlider
{
    public ControlPointAlpha controlPointAlpha;

    public void Update()
    {
        if (controlPointAlpha)
        {
            transform.localPosition = new Vector3(
                -0.5f+controlPointAlpha.dataValue,
                0f,
                0f
            );
        }
    }
}