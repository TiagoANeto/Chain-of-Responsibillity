using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int life = 100;
    public Animator anim;

    void Start(){
        anim = GetComponentInChildren<Animator>();
        life = 100;
    }
    public void TakeDamage(int damageValue){
        life -= damageValue;
        if(life >= 0){
            HUDManager.instance.UpdateLife(life); //atualizacao da vida na hud
            CheckDeath(); //checa se o player morreu a cada hit que ele toma
        }
    }

    public void CheckDeath(){
        if(life <= 0){
            //HUDManager.instance.UpdateLife(0); //pra vida nao ficar negativa caso o player tome outro hit enquanto animacao de morrer
            anim.SetTrigger("death"); //colocar o evento de morrer
            Debug.Log("0 vidas");
        }
    }
}
