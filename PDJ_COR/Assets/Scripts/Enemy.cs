using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int energy; //vida do inimgio
    public int value; //value define quantos pontos o player vai receber quando matar o inimigo
    public void TakeDamage(int damage){
        energy -= damage;
        if(energy <= 0){
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
