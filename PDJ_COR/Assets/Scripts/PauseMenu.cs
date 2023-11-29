using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPause;

    public void Pause(InputAction.CallbackContext context)
    {
        panelPause.SetActive(true);
    }

}
