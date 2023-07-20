using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateTrainingStepManager : MonoBehaviour
{
    public GameObject highlightsparent;
    public GameObject errorMessageNoMarkers;
    public GameObject stepPrefab;
    public GameObject stepParent;
    public TMP_InputField inputField;
    public TMP_Text heading; 
    private string inputText;


    public List<Step> trainingSteps = new List <Step>();

    private int stepCount; 

    // Start is called before the first frame update
    void Start()
    {
        stepCount = 0;
        if (errorMessageNoMarkers.activeSelf)
            errorMessageNoMarkers.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (errorMessageNoMarkers.activeSelf &&
            highlightsparent.transform.childCount > 1)
        {
            errorMessageNoMarkers.SetActive(false);
        }
    }

    public void OnSaveStepButtonClicked()
    {
        if (highlightsparent.transform.childCount <= 1)
        {
            errorMessageNoMarkers.SetActive(true);
        }
        else if (highlightsparent.transform.childCount > 1)
        {
            // Instantiate the prefab of a training step as a child of the "Steps" GameObject in the hierarchy 
            GameObject curStep =  Instantiate(stepPrefab, stepParent.transform);

            trainingSteps.Add(curStep.GetComponent<Step>());

            trainingSteps[stepCount].SetStepID(stepCount);
            trainingSteps[stepCount].description = updateInputField();

            foreach (Transform marker in highlightsparent.transform)
            {
                if (marker.tag == "hint")
                {
                    trainingSteps[stepCount].addHitmarkerAsChild(marker);
                }
            }


            stepCount++;
            heading.text = "Step " + (stepCount + 1).ToString();
        }

    }

    private string updateInputField()
    {
        string description = inputField.text; 
        inputField.text = ""; 
        return description;
    }
}
