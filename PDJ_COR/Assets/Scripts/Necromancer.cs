using UnityEngine;
using System.Collections;

public class Necromancer : MonoBehaviour
{
    //int vida = 100; --> vida do necromante em si
    public Enemy enemyPrefab;
    Enemy enemy;
    public Animator anim;

    void Start(){
        Invoke("callingWaveAnim", 3f); //chama a animação ao inves do metodo de spawnar pq a animação tem um evento de chamar o spawn
    }

    void callingWaveAnim(){
        anim.SetTrigger("callWave");
    }

    public void SpawnWaves(){
        int x = Random.Range(5,9); //numero de inimigos que serao spawnados

        for(int i = 0; i <= x; i++){
            enemy = Instantiate<Enemy>(enemyPrefab, transform.position, transform.rotation); //instancia um objeto ja do tipo Enemy
            enemy.energy = Random.Range(15,21); //cada inimigo instanciado tem energia de 15 a 20 
        }
    }

    //decidir tempo de spawnar
}
