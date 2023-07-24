using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButtonBehaviour : MonoBehaviour
{
    public AuthorModeStepManager trainingStepManager;

    public void ClearHighlights()
    {
        if (trainingStepManager.steps[trainingStepManager.curStep].
            hitMarkerParent.transform.childCount > 0)
        {
            foreach (Transform marker in trainingStepManager.steps[trainingStepManager.curStep].
                hitMarkerParent.transform)
            {
                if(marker.tag == "hint")
                { 
                    Destroy(marker.gameObject);
                }
            }

        }
    } 
}
