using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    public Text txtLife;

    void Awake(){
        if(instance == null){ // instancia do singleton HUDmanager
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateLife(int value){
        txtLife.text = "Life: " + value;
    }


}
