using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InfoPlacementManager : MonoBehaviour
{

    // the green spheres 
    public GameObject hitMarker;

    public AuthorModeStepManager stepManager; 



    // Update is called once per frame
    void Update()
    {
// this part of the script is executed within the Unity Editor 
#if UNITY_EDITOR
        // if the mouse Button is pressed and the mouse is not over a game object (like e.g. UI element)
        if (Input.GetMouseButtonDown(0)
            && !EventSystem.current.IsPointerOverGameObject())
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                // a hit marker gets instantiated at the location, where the ray hits a virtual object
                Instantiate(hitMarker, hit.point, this.transform.rotation,
                    stepManager.steps[stepManager.curStep].hitMarkerParent.transform);
            }
        }

// this part of the script is executed when playing as android app
// the logic is the same, the only difference is that we do not check for mouse input but touch input 
#elif UNITY_ANDROID
        if ((Input.GetTouch(0).phase == TouchPhase.Stationary)
            || (Input.GetTouch(0).phase == TouchPhase.Moved
                && Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(hitMarker, hit.point, this.transform.rotation,
                    stepManager.steps[stepManager.curStep].hitMarkerParent.transform);
            }
            else
            {
            }

        }

#endif

    }
}
