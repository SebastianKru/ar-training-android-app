using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class PlayModeStepManager : MonoBehaviour
{

    public AuthorModeStepManager authorModeStepManager;
    public Button nextStepButton;

    public TMP_Text heading;
    public TMP_Text descriptionText;

    private int curStep;


    // Update is called once per frame
    void Update()
    {
        // enable or disable the next step button
        if (curStep < authorModeStepManager.steps.Count - 1)
        {
            nextStepButton.interactable = true;
        }
        else
        {
            nextStepButton.interactable = false;
        }
    }

    // start the training always from the first step 
    public void OnPlayTrainingButtonPressed()
    {
        curStep = 0;
        ShowStep(curStep);
    }

    // disable the current step
    // if a user goes back to the main menu 
    public void OnMenuButtonPressed()
    {
        authorModeStepManager.steps[curStep].disableStep();
    }

    // enable the next step of a training
    public void OnNextStepButtonPressed()
    {
        if (curStep < authorModeStepManager.steps.Count -1)
        {
            authorModeStepManager.steps[curStep].disableStep();
            curStep++;
            ShowStep(curStep);
        }
    }

    // enable a step and load the description text into the text field 
    private void ShowStep(int i)
    {
        if (authorModeStepManager.steps.Count > 0)
        {
            authorModeStepManager.steps[i].enableStep();
            descriptionText.text = authorModeStepManager.steps[i].description;
            heading.text = "step " + (i + 1).ToString() + " of "
                + (authorModeStepManager.steps.Count).ToString() + " steps";
        }
    }

}
