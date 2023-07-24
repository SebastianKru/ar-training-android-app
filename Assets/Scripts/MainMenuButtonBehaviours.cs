using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonBehaviours : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject createTrainingUI;
    public GameObject playTrainingUI; 
    // Start is called before the first frame update
    void Start()
    {
        if(createTrainingUI.activeSelf)
            createTrainingUI.SetActive(false);

        if (playTrainingUI.activeSelf)
            playTrainingUI.SetActive(false);

        if (!mainMenuUI.activeSelf)
            mainMenuUI.SetActive(true);

    }

    public void CreateTrainingClicked()
    {
        mainMenuUI.SetActive(false);
        createTrainingUI.SetActive(true);
    }

    public void PlayTrainingClicked()
    {
        mainMenuUI.SetActive(false);
        playTrainingUI.SetActive(true);
    }

    public void MenuClicked()
    {
        mainMenuUI.SetActive(true);
        createTrainingUI.SetActive(false);
        playTrainingUI.SetActive(false);
    }
}
