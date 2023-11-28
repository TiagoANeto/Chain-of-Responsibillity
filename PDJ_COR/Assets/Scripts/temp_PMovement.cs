using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class temp_PMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float gravity = 10.0f; 
    public float verticalVelocity = 0.0f;
    public float speed = 70;
    public Vector2 movement;
    public Animator anim;
    private Vector3 rotation;
    public float rotationSpeed = 2.0f; // Adjust this value to control the rotation speed
    
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
        if (characterController.isGrounded)
        {
            //float mouseX = Input.GetAxis("Mouse X");
            rotation = new Vector3(0, Input.GetAxis("Mouse X") * 60f * Time.deltaTime, 0);
            //transform.Rotate(0, rotationAmount, 0);

            // Obtém a direção do movimento
            Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);

            // Aplica o movimento à posição do jogador
            characterController.Move(moveDirection * speed * Time.deltaTime);
            transform.Rotate(rotation);

            // Zera a velocidade vertical se estivermos no chão
            verticalVelocity = 0;
            anim.SetFloat("walkIdle", moveDirection.magnitude);
        }
        // Se não estiver no chão, aplica a gravidade
        verticalVelocity -= gravity * Time.deltaTime;
        // Aplica a velocidade vertical à posição do jogador
        characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }
}
