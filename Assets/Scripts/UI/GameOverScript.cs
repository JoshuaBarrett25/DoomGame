using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnReturn()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
