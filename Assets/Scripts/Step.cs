using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a training consists out of steps
// each step has a description which tells a trainee what he has to do
// as well as a number of markers which tell a trainee where to look
public class Step : MonoBehaviour
{
    public string description;
    public GameObject hitMarkerParent;

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
        hitMarkerParent.SetActive(true);
    }

    public void disableStep()
    {
        hitMarkerParent.SetActive(false);
    }
}
