using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InfoPlacementManager : MonoBehaviour
{

    public GameObject hitMarker;
    public GameObject debugTextGO;

    private TMP_Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        debugText = debugTextGO.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)
            && !EventSystem.current.IsPointerOverGameObject())
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 localHit = transform.InverseTransformPoint(hit.point);
                Debug.Log(localHit);
                Instantiate(hitMarker, hit.point, this.transform.rotation,this.transform);
                debugText.text = ("hit");
            }
            else
            {
                debugText.text = ("missed");
            }
        }

#elif UNITY_ANDROID 
        if ((Input.GetTouch(0).phase == TouchPhase.Stationary)
            || (Input.GetTouch(0).phase == TouchPhase.Moved
                && Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(hitMarker, hit.point, this.transform.rotation, this.transform);
                debugText.text = ("hit");
            }
            else
            {
                debugText.text = ("missed");
            }

        }

#endif

    }
}
