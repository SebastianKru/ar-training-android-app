using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPlacementManager : MonoBehaviour
{

    public GameObject hitMarker; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 localHit = transform.InverseTransformPoint(hit.point);
                Debug.Log(localHit);
                Instantiate(hitMarker, hit.point, this.transform.rotation,this.transform);
            }
            else
            {
                Debug.Log("missed");
            }
        }
    }
}
