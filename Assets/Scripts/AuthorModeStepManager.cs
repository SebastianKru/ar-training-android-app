using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO: Maybe add buttons to go forward and backwards in the edit process 
public class AuthorModeStepManager : MonoBehaviour
{
    public GameObject errorMessageNoMarkers;
    public GameObject stepPrefab;
    public GameObject stepParent;
    public TMP_InputField inputField;
    public Button backButton;
    public Button forwardButton; 

    public TMP_Text headingCreateTraining;

    public List<Step> steps = new List <Step>();
    public int curStep = 0;


    void Start()
    {
        if (errorMessageNoMarkers.activeSelf)
            errorMessageNoMarkers.SetActive(false);
    }

    void Update()
    {
        if (errorMessageNoMarkers.activeSelf &&
            steps[curStep].hitMarkerParent.transform.childCount > 0)
        {
            errorMessageNoMarkers.SetActive(false);
        }

        if(curStep > 0)
        {
            backButton.interactable = true; 
        }
        else
        {
            backButton.interactable = false;
        }

        if (curStep < steps.Count-1)
        {
            forwardButton.interactable = true;
        }
        else
        {
            forwardButton.interactable = false;
        }

    }


    public void OnCreateTrainingButtonPressed()
    {
        if(steps.Count == 0)
        {
            CreateNewStep(); 
        }
    }

    public void OnMenuButtonPressed()
    {
        if (errorMessageNoMarkers.activeSelf)
            errorMessageNoMarkers.SetActive(false);

        Destroy(steps[curStep].gameObject);
        steps.RemoveAt(curStep);
        curStep--;
    }

    public void OnBackButtonPressed()
    {
        steps[curStep].disableStep(); 
        curStep--;
        ShowStep(curStep);
    }

    public void OnForwardButtonPressed()
    {
        steps[curStep].disableStep();
        curStep++;
        ShowStep(curStep);
    }

    public void OnSaveStepButtonClicked()
    {
        if (steps[curStep] == null
            || steps[curStep].hitMarkerParent.transform.childCount == 0)
        {
            errorMessageNoMarkers.SetActive(true);
        }
        else if (curStep == steps.Count-1)
        {
            steps[curStep].description = updateInputField();
            steps[curStep].disableStep();
            CreateNewStep();
        }
        else
        {
            steps[curStep].description = updateInputField();
            steps[curStep].disableStep();
            curStep++;
            ShowStep(curStep);
        }
    }


    private void CreateNewStep()
    {
        GameObject newStep = Instantiate(stepPrefab, stepParent.transform);
        steps.Add(newStep.GetComponent<Step>());

        if (steps.Count == 1)
            curStep = 0;
        else if (steps.Count > 1)
            curStep++;

        steps[curStep].name = "Step " + (curStep + 1).ToString();
        UpdateHeading(curStep);
    }

    private void ShowStep(int i)
    {
        steps[i].enableStep();
        UpdateHeading(i);
        inputField.text = steps[i].description;
    }

    private void UpdateHeading(int i)
    {
        headingCreateTraining.text = "Step " + (i + 1).ToString();

    }

    private string updateInputField()
    {
        string description = inputField.text; 
        inputField.text = ""; 
        return description;
    }
}
