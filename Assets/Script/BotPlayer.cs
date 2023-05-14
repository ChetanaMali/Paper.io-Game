using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround;
    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_PlayerLineRen, m_Pcylinder;
    [SerializeField] GameObject textLoos;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        Patroling();
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            GameManager.instance.m_IsBotMove= true;
        }
            
            

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerLine")
        {
            AudioManager.Instance.PlayerDie();
            Debug.Log("Bot collider to player line");
            m_Player.SetActive(false);
            m_Pcylinder.SetActive(false);
            m_PlayerLineRen.SetActive(false);
            textLoos.SetActive(true);
            //Destroy(m_Player);
        }
    }
}
