using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButtonBehaviour : MonoBehaviour
{
    public GameObject highlightsparent;

    public void ClearHighlights()
    {
        if(highlightsparent.transform.childCount > 1)
        {
            foreach (Transform highlight in highlightsparent.transform)
            {
                if(highlight.tag == "hint")
                { 
                    Destroy(highlight.gameObject);
                }
            }

        }
    } 
}
