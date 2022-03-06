using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject pause;
   public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!pause.activeSelf)
            {
                pause.SetActive(true);
                Time.timeScale = 0f;
            }
            else
                Continue();
        }
        
    }
}
