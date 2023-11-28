using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float gravity = 10.0f; 
    public float verticalVelocity = 0.0f;
    public float speed = 70;
    public Vector2 movement;

    public GameObject lookAt;


    
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
    }

    void Update()
    {
        Look();
    }


    void FixedUpdate()
    {
        // Verifica se o jogador está no chão
        if (characterController.isGrounded )
        {
            // Obtém a direção do movimento
            Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);

            // Aplica o movimento à posição do jogador
            characterController.Move(moveDirection * speed * Time.fixedDeltaTime);

            // Zera a velocidade vertical se estivermos no chão
            verticalVelocity = 0;
        }
        // Se não estiver no chão, aplica a gravidade
        verticalVelocity -= gravity * Time.fixedDeltaTime;
        // Aplica a velocidade vertical à posição do jogador
        characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.fixedDeltaTime);
    }


    void Look()
    {
        // Obtém a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula a direção do objeto para o mouse
        Vector3 lookDir = mousePos - transform.position;

        // Calcula o ângulo de rotação em radianos
        float angle = Mathf.Atan2(lookDir.y, lookDir.x);

        // Converte o ângulo para graus
        float angleDegrees = angle * Mathf.Rad2Deg;

        // Rotaciona o objeto na direção do mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, angleDegrees,0 ));
    }

    // private void Attack(){
    //    Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

    //    foreach(Collider enemy in hitEnemies){
    //     Debug.Log("We hit" + enemy.name);
    //    }
    // }
}
