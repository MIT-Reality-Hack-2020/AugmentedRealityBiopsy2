using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour
{

    public virtual void Enable()
    {

    }

    public virtual void Disable()
    {

    }

    public virtual void UpdateInterface()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }

    public void OnEnable()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnDisable()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
