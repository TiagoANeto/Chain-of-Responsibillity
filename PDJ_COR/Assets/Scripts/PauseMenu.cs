using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelOptions;
    public GameObject panelSkills;
    public GameObject panelFire;

    //Passando o contexto do que vai acontecer ao pressionar a tecla ESC
    public void Pause(InputAction.CallbackContext context)
    {
        panelPause.SetActive(true);
        TogglePauseMenu();
    }
    
    public void TogglePauseMenu()
    { 
        if (panelPause.activeSelf)
        {
            Time.timeScale = 0f; // Pausa o tempo do jogo
        }
    }

    public void Resume()
    {
        panelPause.SetActive(false);

        Time.timeScale = 1f;
    }

    public void OptionsPause()
    {
        panelPause.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void CloseFire()
    {
        panelSkills.SetActive(false);
    }

     public void Cheat(InputAction.CallbackContext context)
    {
        panelFire.SetActive(true);
    }

    public void CheatOff()
    {
        panelFire.SetActive(false);
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
