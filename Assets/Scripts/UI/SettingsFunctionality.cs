using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsFunctionality : MonoBehaviour
{
    public GameSettings gameSettings;
    public TextMeshProUGUI mouseSensValue;

    private void Update()
    {
        mouseSensValue.text = gameSettings.mouseSens.ToString();
    }

    public void MouseSensIncrease()
    {
        gameSettings.mouseSens += 1;
        if (gameSettings.mouseSens >= 15)
        {
            gameSettings.mouseSens = 15;
        }
    }

    public void MouseSensDecrease()
    {
        gameSettings.mouseSens -= 1;
        if (gameSettings.mouseSens <= 1)
        {
            gameSettings.mouseSens = 1;
        }
    }
}
