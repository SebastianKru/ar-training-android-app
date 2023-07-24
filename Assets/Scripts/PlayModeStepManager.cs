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
        if (curStep < authorModeStepManager.steps.Count - 1)
        {
            nextStepButton.interactable = true;
        }
        else
        {
            nextStepButton.interactable = false;
        }
    }

    public void OnPlayTrainingButtonPressed()
    {
        curStep = 0;
        ShowStep(curStep);
    }


    public void OnMenuButtonPressed()
    {
        authorModeStepManager.steps[curStep].disableStep();
        curStep = 0; 
    }

    public void OnNextStepButtonPressed()
    {
        if (curStep < authorModeStepManager.steps.Count -1)
        {
            authorModeStepManager.steps[curStep].disableStep();
            curStep++;
            ShowStep(curStep);
        }
    }

    private void ShowStep(int i)
    {
        authorModeStepManager.steps[i].enableStep();
        descriptionText.text = authorModeStepManager.steps[i].description;
        heading.text = "step " + (i + 1).ToString() + " of "
            + (authorModeStepManager.steps.Count).ToString() + " steps";
    }

}
