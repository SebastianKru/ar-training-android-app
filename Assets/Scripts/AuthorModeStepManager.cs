using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthorModeStepManager : MonoBehaviour
{
    // an error message if a user wants to save a step without placing a marker. 
    public GameObject errorMessageIfNoMarkers;
    // the prefab of a step
    public GameObject stepPrefab;
    // the parent of all our step objects (Unity hierarchy) 
    public GameObject stepParent;
    // the input field which an author uses to input the text of a step
    public TMP_InputField inputField;

    // forward and backwards < > buttons 
    public Button backButton;
    public Button forwardButton; 

    // the heading like "step 1"
    public TMP_Text heading;

    // our list of training steps 
    public List<Step> steps = new List <Step>();

    // an iterator for the currently active step 
    public int curStep = 0;


    void Start()
    {
        // always disable the error message on start 
        if (errorMessageIfNoMarkers.activeSelf)
            errorMessageIfNoMarkers.SetActive(false);
    }

    void Update()
    {
        // if the error message is not valid anymore, disable it 
        if (errorMessageIfNoMarkers.activeSelf &&
            steps[curStep].hitMarkerParent.transform.childCount > 0)
        {
            errorMessageIfNoMarkers.SetActive(false);
        }

        // the following if else statements handle the interactive state of the back and forward buttons 
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

    // only if an author has not created a step yet we have to create a step, otherwise, nothing has to be done 
    public void OnCreateTrainingButtonPressed()
    {
        if(steps.Count == 0)
        {
            CreateNewStep(); 
        }
    }

    // if a user wants to go back to the menu
    public void OnMenuButtonPressed()
    {
        // disable the error message 
        if (errorMessageIfNoMarkers.activeSelf)
            errorMessageIfNoMarkers.SetActive(false);

        // destroy the last step as the user has not saved this step 
        Destroy(steps[steps.Count-1].gameObject);
        steps.RemoveAt(steps.Count - 1);
        curStep--;
    }

    // go one step back in authoring mode 
    public void OnBackButtonPressed()
    {
        steps[curStep].disableStep(); 
        curStep--;
        ShowStep(curStep);
    }

    // go one step forward in authoring mode 
    public void OnForwardButtonPressed()
    {
        steps[curStep].disableStep();
        curStep++;
        ShowStep(curStep);
    }


    public void OnSaveStepButtonClicked()
    {
        // dispaly an error message if the user forgot to place a marker 
        if (steps[curStep] == null
            || steps[curStep].hitMarkerParent.transform.childCount == 0)
        {
            errorMessageIfNoMarkers.SetActive(true);
        }
        // if the current step is the last step of the training,
        // saving instantiates a new step 
        else if (curStep == steps.Count-1)
        {
            steps[curStep].description = updateInputField();
            steps[curStep].disableStep();
            CreateNewStep();
        }
        else
        {
            // if the current step is not the last step, pressing "save and create next step"
            // just jumps to the next step 
            steps[curStep].description = updateInputField();
            steps[curStep].disableStep();
            curStep++;
            ShowStep(curStep);
        }
    }

    // creates a new step for the training
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

    // is used if a user goes backwards or forwards through the steps
    // updates the necessary fields, so that a step is displayed 
    private void ShowStep(int i)
    {
        steps[i].enableStep();
        UpdateHeading(i);
        inputField.text = steps[i].description;
    }

    // the heading liek "step 3" 
    private void UpdateHeading(int i)
    {
        heading.text = "Step " + (i + 1).ToString();

    }

    // if called the text of an inoput field gets returned and the input field is reset 
    private string updateInputField()
    {
        string description = inputField.text; 
        inputField.text = ""; 
        return description;
    }
}
