using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public string description;
    public GameObject hitMarkerParent;
    //public GameObject [] hitMarkers;

    public int stepID;

    public void SetStepID(int id)
    {
        stepID = id + 1;
        this.gameObject.name = "Step " + stepID.ToString(); 
    }

    public void addHitmarkerAsChild(Transform marker)
    {
        marker.SetParent(hitMarkerParent.transform);
        marker.gameObject.SetActive(false);
    }

    public void enableStep()
    {

    }

    public void disableStep()
    {

    }
}
