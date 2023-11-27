using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

    void Update(){
        if(Input.GetKeyDown(KeyCode.U)){
            anim.SetTrigger("attack1");
        }
        if(Input.GetKeyDown(KeyCode.I)){
            anim.SetTrigger("attack2");
        }
        if(Input.GetKeyDown(KeyCode.O)){
            anim.SetTrigger("getHit");
        }
        if(Input.GetKeyDown(KeyCode.P)){
            anim.SetTrigger("death");
        }
    }

}
