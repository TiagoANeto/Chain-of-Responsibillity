using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;

    void Update(){
        if(Input.GetKeyDown(KeyCode.U)){
            anim.SetTrigger("death");
        }
    }

}
