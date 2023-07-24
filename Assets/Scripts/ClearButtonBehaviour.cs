using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a small helper script for the logic of the button which clears markers 
public class ClearButtonBehaviour : MonoBehaviour
{
    public AuthorModeStepManager trainingStepManager;

    public void ClearHighlights()
    {
        // we only want to delete markers if the current step has more than 0 markers
        if (trainingStepManager.steps[trainingStepManager.curStep].
            hitMarkerParent.transform.childCount > 0)
        {
            // loop over all existing markers 
            foreach (Transform marker in trainingStepManager.steps[trainingStepManager.curStep].
                hitMarkerParent.transform)
            {
                // for double safety check if they are of type hint
                if(marker.tag == "hint")
                {
                    // destroy the identified marker 
                    Destroy(marker.gameObject);
                }
            }

        }
    } 
}
