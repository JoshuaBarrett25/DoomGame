using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    public GameSettings gameSettings;
    bool titleScreen = true;
    public GameObject titleGroup;
    public GameObject difficultyOptions;
    public GameObject mainMenuOptions;
    public GameObject settingsOptions;

    float flashDuration = 1;
    float flashInputTimer = 0.0f;
    bool flashText = true;
    public GameObject inputText;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }


    private void Update()
    {
        if (titleScreen)
        {
            flashInputTimer += Time.deltaTime;
            if (flashInputTimer > flashDuration)
            {
                if (flashText)
                {
                    Debug.Log("flash off!");
                    flashInputTimer = 0;
                    inputText.SetActive(false);
                    flashText = false;
                    flashDuration = 1;
                }

                else if (!flashText)
                {
                    Debug.Log("flash on!");
                    flashInputTimer = 0;
                    inputText.SetActive(true);
                    flashText = true;
                    flashDuration = 1;
                }
            }

            if (Input.anyKey)
            {
                titleScreen = false;
                titleGroup.SetActive(false);
                mainMenuOptions.SetActive(true);
            }
        }
    }

    public void OnPlay()
    {
        mainMenuOptions.SetActive(false);
        difficultyOptions.SetActive(true);
    }

    public void OnSettings()
    {
        mainMenuOptions.SetActive(false);
        settingsOptions.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        difficultyOptions.SetActive(false);
        settingsOptions.SetActive(true);
        mainMenuOptions.SetActive(true);
    }



    public void OnDifficultySelect(int difficultyIndex)
    {
        SceneManager.LoadScene(1);
        gameSettings.damageIndex = difficultyIndex;
        Cursor.visible = false;
    }
}
