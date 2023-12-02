using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int energy; //vida do inimgio
    int value; //value define quantos pontos o player vai receber quando matar o inimigo]

    void Update(){
        if(energy <= 0){
            //animação de morte
            Destroy(gameObject);
            //gameManager.instance.AddPoints(value);
        }
    }
}
