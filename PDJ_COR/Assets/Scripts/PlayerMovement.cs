using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float gravity = 20.0f; 
    public float verticalVelocity = 0.0f;
    public float speed = 70;
    public Vector2 movement;

    
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
        // Verifica se o jogador está no chão
        if (!characterController.isGrounded )
        {
            // Obtém a direção do movimento
            Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);

            // Aplica o movimento à posição do jogador
            characterController.Move(moveDirection * speed * Time.deltaTime);

            // Zera a velocidade vertical se estivermos no chão
            verticalVelocity = 0;
        }
        else
        {
            // Se não estiver no chão, aplica a gravidade
            verticalVelocity -= gravity * Time.deltaTime;
        }

            // Aplica a velocidade vertical à posição do jogador
            characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }
}
