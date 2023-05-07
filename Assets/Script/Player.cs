using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Player Variable")]
    [SerializeField] CharacterController m_CharacterController;
    [SerializeField] float m_MovementSpeed, m_TurnSpeed;

    private float x, z;

    [Header ("Line Render")]
    LineRenderer m_Line;
    [SerializeField] float m_MinDistance = 0.1f;

    private Vector3 previousPosiotion;
    //[SerializeField] float m_width = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();

        m_Line = GetComponent<LineRenderer>();
        m_Line.positionCount = 1;
        previousPosiotion = transform.position;
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
        z = Input.GetAxisRaw("Horizontal") * m_TurnSpeed * Time.deltaTime;

        //Player Movement
        m_CharacterController.Move(transform.forward * x);
        transform.Rotate(Vector3.up * z);
    }
    void LineDraw()
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
    }
}
