using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;
    public void Dead(){
        //SceneManager.LoadScene("gameOver");
        HUDManager.instance.YouDied();
        Time.timeScale = 0.0f;
        Debug.Log("você morreu!");
    }

}
