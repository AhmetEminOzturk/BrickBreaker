using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneSc : MonoBehaviour
{

    public void StartBut()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitBut()
    {
        Application.Quit();
    }
    
}
