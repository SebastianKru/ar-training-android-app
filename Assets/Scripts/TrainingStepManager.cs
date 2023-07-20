using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// rename to TrainingStepManager
public class TrainingStepManager : MonoBehaviour
{
    public GameObject errorMessageNoMarkers;
    public GameObject stepPrefab;
    public GameObject stepParent;
    public TMP_InputField inputField;

    public TMP_Text headingCreateTraining;
    public TMP_Text headingPlayTraining;
    public TMP_Text descriptionTextPlayTraining; 

    public List<Step> steps = new List <Step>();

    public int curStep_Create;

    private int curStep_Play; 

    void Start()
    {
        if (errorMessageNoMarkers.activeSelf)
            errorMessageNoMarkers.SetActive(false);
    }

    public void OnCreateTrainingButtonPressed()
    {
        if(steps.Count == 0)
        {
            CreateNewStep(); 
        }
    }

    public void OnMenuButtonPressedFromCreate()
    {
        steps[curStep_Create].disableStep();
    }

    public void OnMenuButtonPressedFromPlay()
    {
        steps[curStep_Play].disableStep();
    }

    public void OnPlayTrainingButtonPressed()
    {
        curStep_Play = 0;
        ShowStep(curStep_Play); 
    }

    public void OnNextStepButtonPressed()
    {
        if(curStep_Play < steps.Count-1)
        {
            steps[curStep_Play].disableStep();
            curStep_Play++;
            ShowStep(curStep_Play);
        }

        // TODO else grey button
    }

    private void ShowStep (int i)
    {
        steps[i].enableStep();
        descriptionTextPlayTraining.text = steps[i].description; 
        headingPlayTraining.text = "step " + (i+1).ToString() +  " of "
            + steps.Count.ToString() + " steps";
    }


    void Update()
    {
        if (errorMessageNoMarkers.activeSelf &&
            steps[curStep_Create].hitMarkerParent.transform.childCount > 0)
        {
            errorMessageNoMarkers.SetActive(false);
        }
    }

    public void OnSaveStepButtonClicked()
    {
        if (steps[curStep_Create] == null
            || steps[curStep_Create].hitMarkerParent.transform.childCount == 0)
        {
            errorMessageNoMarkers.SetActive(true);
        }
        else if (steps[curStep_Create].hitMarkerParent.transform.childCount != 0)
        {
            steps[curStep_Create].description = updateInputField();
            steps[curStep_Create].disableStep();
            CreateNewStep();
        }
    }

    private void CreateNewStep()
    {
        GameObject newStep = Instantiate(stepPrefab, stepParent.transform);
        steps.Add(newStep.GetComponent<Step>());

        if (steps.Count == 1)
            curStep_Create = 0;
        else if (steps.Count > 1)
            curStep_Create++;

        headingCreateTraining.text = "Step " + (curStep_Create + 1).ToString();
        steps[curStep_Create].name = "Step " + (curStep_Create + 1).ToString();

    }

    private string updateInputField()
    {
        string description = inputField.text; 
        inputField.text = ""; 
        return description;
    }
}
