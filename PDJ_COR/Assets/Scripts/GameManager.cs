using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake(){
        if(instance == null){ // instancia do singleton HUDmanager
            instance = this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
        HUDManager.instance.txtLife.text = "Life: " + 100;
    }
}
