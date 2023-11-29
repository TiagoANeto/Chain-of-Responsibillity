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
    public Transform player;
    public float rotationSpeed = 5.0f; 
    public Ray ray;
    public RaycastHit hit; 
    public bool freezeY = true;
    
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

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
            // Obtém a direção do movimento
            Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);

            // Aplica o movimento à posição do jogador
            characterController.Move(moveDirection * speed * Time.deltaTime);
            

            anim.SetFloat("walkIdle", moveDirection.magnitude);
        }

        verticalVelocity -= gravity * Time.deltaTime;
       
        characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(!Physics.Raycast(ray, out hit)){
            return;
        }


        Vector3 pos = hit.point - player.position;

        if(freezeY){
            pos.y = 0;
        }

        Quaternion rot = Quaternion.LookRotation(pos);

        //player.rotation = Quaternion.Lerp(player.rotation, rot, rotationSpeed * Time.deltaTime);
        
    }

    private void Attack()
    {
       Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

       foreach(Collider enemy in hitEnemies){
        Debug.Log("We hit" + enemy.name);
       }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint==null){
            return;
        }
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
