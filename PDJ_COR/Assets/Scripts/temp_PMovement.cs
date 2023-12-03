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
    public float moveRotationSpeed = 5.0f;
    public Ray ray;
    public RaycastHit hit; 
    public bool freezeY = true;
    public Quaternion rot;
    
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage = 20;

    public float dashCooldown = 0f; // Tempo de espera entre dashes
    public float dashDuration = 1f; // Duração do dash
    public float dashSpeed = 150.0f; // Velocidade do dash
    private bool canDash = true; // Indica se o jogador pode dar um dash
    public float dashDistance = 3.0f;

    public GameObject fireball;
    
    public Vector3 moveDirection;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
    }

    void FixedUpdate()
    { 

        fireball.transform.position += fireball.transform.forward * Time.deltaTime * 10;

    }
    void Update()
{
    // Verifica se o jogador está no chão
    if (characterController.isGrounded)
    {
        // Obtém a direção do movimento
        moveDirection = new Vector3(movement.x, 0, movement.y);

        // Se houver movimento, rotaciona o jogador suavemente na direção do movimento
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);
            player.rotation = Quaternion.Slerp(player.rotation, targetRotation, moveRotationSpeed * Time.deltaTime);
        }

        // Aplica o movimento à posição do jogador
        characterController.Move(moveDirection * speed * Time.deltaTime);

        anim.SetFloat("walkIdle", moveDirection.magnitude);
    }

    verticalVelocity -= gravity * Time.deltaTime;

    characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);


    ray = Camera.main.ScreenPointToRay(Input.mousePosition); //pega a poisiçaõ do mouse pra poder rotacionar o jogador quando clicar

    if (!Physics.Raycast(ray, out hit))
    {
        return;
    }

    Vector3 pos = hit.point - player.position;

    if (freezeY)
    {
        pos.y = 0;
    }

    rot = Quaternion.LookRotation(pos);
}

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.started) //Ocorre apenas no frame em que foi pressionado
        {
            player.rotation = Quaternion.Lerp(player.rotation, rot, rotationSpeed * Time.deltaTime);
            
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers); //coloca todos os inimigos colididos dentro de um array
            anim.SetTrigger("attack");

            foreach(Collider enemy in hitEnemies) //causa dano à todos os inimigos no array
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    // public void Fireball(InputAction.CallbackContext context){
    //     if(context.started){
    //         Instantiate(fireball, attackPoint.position, attackPoint.rotation);
    //         //Vector3 dir = new Vector3();
    //     }
    // }

    void OnDrawGizmosSelected()
    {
        if(attackPoint==null){
            return;
        }
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && canDash) // A ação de dash foi iniciada e o jogador pode dar um dash
        {         
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        canDash = false; // Impede que o jogador dê um dash enquanto o cooldown estiver ativo

        float timer = 0.0f;
        float originalSpeed = speed; // Salva a velocidade original do jogador
        speed = dashSpeed; // Aumenta a velocidade para o dash

        while (timer < dashDuration)
        {
            Debug.Log("dash");
            Vector3 dashVector = moveDirection * dashDistance * 0.01f;
            characterController.Move(dashVector);

            timer += Time.deltaTime;
            yield return null;
        }

        speed = originalSpeed; // Restaura a velocidade original após o dash
        yield return new WaitForSeconds(1);

        canDash = true; // Permite que o jogador dê um novo dash após o cooldown
    }

}
