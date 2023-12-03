using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public string scene;

    public void OnClickButton(){
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
