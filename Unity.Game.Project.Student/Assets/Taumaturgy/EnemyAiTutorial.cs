using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    //public Vector3 HitPointWithHead;

    public LayerMask whatIsGround, whatIsPlayer;//класна фігня але дисить замудрена

    public Animator anim;

    private Color rayColor = Color.red;

    public float reyAttakc;

    public Transform sword;


    private bool SwordMove;



    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    private bool swordWalkPoint;


    //Attackin

    // public bool SuperAttack = true;


    //States
    public float sightRange, attackRange, superAttackRange;
    public bool playerInSightRange, playerInAttackRange, playerInSuperAtackRange;

    // triger skript
    //public playerScript otherScript;
    public Vector3 HitPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
        //reyAttakc = superAttackRange;
    }

    private void Update()
    {
        //Шари для розуміння який режим потрібно
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInSuperAtackRange = Physics.CheckSphere(transform.position, superAttackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && playerInSuperAtackRange) AttackPlayer();
        if (playerInSightRange && !playerInAttackRange && !playerInSuperAtackRange)
        {
            Vector3 playerDirection = (player.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerDirection, out hit, sightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    ChasePlayer();
                }
                else Patroling();
            }


        }
        if (sword.parent == null && SwordMove && swordWalkPoint)
        {
            sword.position = Vector3.Lerp(sword.position, new Vector3(HitPoint.x , HitPoint.y - 0.4f, HitPoint.z - 2f), 0.04f);

        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        // шукаєм точку на осі X та Z 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {

        agent.SetDestination(player.position);
        //Debug.Log("Гравець видно!");


    }

    private void AttackPlayer()
    {
        Vector3 playerY = (player.position);
        playerY.y = transform.position.y;
        transform.LookAt(playerY);

        if (playerInAttackRange)
        {
            anim.SetBool("atack", true);
            agent.SetDestination(transform.position);
        }
        else
        {
            anim.SetBool("atack", false);

           // if (otherScript.SuperAttack)
         //  {
                Vector3 HitPointWithHead = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z);
                RaycastHit[] hits = Physics.RaycastAll(HitPointWithHead, transform.forward, reyAttakc);

                // Перебираємо всі зіткнення
                for (int i = 0; i < hits.Length; i++)
                {

                    RaycastHit hit = hits[i];
                    /// Debug.DrawRay(transform.position, transform.forward * hit.distance, rayColor);
                    if (hits[0].collider.CompareTag("Player") && hits.Length >= 2 && hits[1].collider.CompareTag("walk"))
                    {
                        agent.SetDestination(transform.position);
                        HitPoint = hits[1].point;
                        // sword.rotation = sword.rotation(0f, sword.rotation, 0f);
                        // sword.LookAt(playerY);
                        anim.SetBool("superAtack", true);
                        Debug.Log("Зіткнення " + (i + 1) + ": " + hit.collider.name);
                        Debug.DrawRay(HitPointWithHead, transform.forward * hit.distance, rayColor);
                        swordWalkPoint = true;
                    }
                    else
                    {
                        ChasePlayer();

                    }

                }
           /* }
            else
            {
               // ChasePlayer();
                anim.SetBool("superAtack", false);
            }*/
        }


        //if (!alreadyAttacked)

        //тіпо атака))

        // таймер атаки шось тіпа цього
        /* timer += Time.deltaTime;
         if (timer >= timeAttacks )
         {
             timer = 0f;
             alreadyAttacked = true;
             Invoke(nameof(ResetAttack), timeBetweenAttacks);//ахуєно робить
         }*/

    }




    //робим шаріки видними в сцені
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, superAttackRange);
    }

    void EvenTrigger()
    {
        SwordMove = true;
        sword.SetParent(null);
        //otherScript.SuperAttack = false;
    }

}
