using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Player Variable")]
    [SerializeField] CharacterController m_CharacterController;
    [SerializeField] Rigidbody m_Rigidbody;
    [SerializeField] float m_MovementSpeed, m_TurnSpeed;
    Vector3 m_EulerAngleVelocity = new Vector3(0,0, 180);
    private float x, z;

    [Header("Bots")]
    [SerializeField] GameObject m_Bot1;
    [SerializeField] GameObject m_Bot2;
    [SerializeField] GameObject m_Bot3;

    [Header("BotsLine")]
    [SerializeField] GameObject m_BotLine1;
    [SerializeField] GameObject m_BotLine2;
    [SerializeField] GameObject m_BotLine3;

    /*[Header ("Line Render")]
    LineRenderer m_Line;
    [SerializeField] float m_MinDistance = 0.1f;

    private Vector3 previousPosiotion;
    //[SerializeField] float m_width = 0.1f;
    */
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody= GetComponent<Rigidbody>();
        //m_CharacterController = GetComponent<CharacterController>();

        //m_Line = GetComponent<LineRenderer>();
        //m_Line.positionCount = 1;
        //previousPosiotion = transform.position;
    }
    void Update()
    {
        PlayerMovement();
        //LineDraw();
    }
    
    void PlayerMovement()
    {
        //Input
        x = Input.GetAxisRaw("Vertical") * m_MovementSpeed * Time.deltaTime; 
        z = Input.GetAxisRaw("Horizontal") * m_MovementSpeed * Time.deltaTime;
        Vector3 playerInput = new Vector3(z,0.5f,x);
        //Player Movement
        //m_CharacterController.Move(transform.forward * x);
        float turnvalue = Input.GetAxisRaw("Horizontal") * m_MovementSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * m_TurnSpeed);
        m_Rigidbody.MovePosition(transform.position + playerInput);

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }
    /*void LineDraw()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y = 0.1f;
            if (Vector3.Distance(currentPosition, previousPosiotion) > m_MinDistance)
            {
                if (previousPosiotion == transform.position)
                {
                    m_Line.SetPosition(0, currentPosition);
                }
                else
                {
                    m_Line.positionCount++;
                    m_Line.SetPosition(m_Line.positionCount - 1, currentPosition);
                }

                previousPosiotion = currentPosition;
            }
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerLine1")
        {
            m_Bot1.SetActive(false);
            m_BotLine1.SetActive(false);
        }
        if (collision.gameObject.tag == "PlayerLine2")
        {
            m_Bot2.SetActive(false);
            m_BotLine2.SetActive(false);
        }
        if (collision.gameObject.tag == "PlayerLine3")
        {
            m_Bot3.SetActive(false);
            m_BotLine3.SetActive(false);
        }
    }
}
