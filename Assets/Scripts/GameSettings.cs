using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public int mouseSens = 10;
    public int[] damageScalar;
    public int damageIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 35;
    }
}
