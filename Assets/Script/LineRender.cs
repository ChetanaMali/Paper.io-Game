using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    LineRenderer m_Line;
    [SerializeField] GameObject m_Player;
    [SerializeField] float m_MinDistance = 0.1f;
    private Vector3 previousPosiotion;


    // Start is called before the first frame update
    void Start()
    {
        m_Line = GetComponent<LineRenderer>();
        m_Line.positionCount = 1;
        previousPosiotion = m_Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LineDraw();
    }
    void LineDraw()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 currentPosition = m_Player.transform.position;
            currentPosition.y = 0.1f;
            if (Vector3.Distance(currentPosition, previousPosiotion) > m_MinDistance)
            {
                if (previousPosiotion == m_Player.transform.position)
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
