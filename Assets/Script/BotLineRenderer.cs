using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLineRenderer : MonoBehaviour
{
    LineRenderer m_Line;
    [SerializeField] GameObject m_Player;
    [SerializeField] float m_MinDistance = 0.1f;
    private Vector3 previousPosiotion;


    // Start is called before the first frame update
    void Start()
    {

        m_Line = GetComponent<LineRenderer>();
        m_Line.positionCount = 0;
        previousPosiotion = m_Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LineDraw();
        SetColliderToLine();
    }
    void LineDraw()
    {
        if(GameManager.instance.m_IsBotMove)
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
                //m_Line.SetColors(Color.blue, Color.blue);
                previousPosiotion = currentPosition;
            }
        }
        
    }
    void SetColliderToLine()
    {
        MeshCollider collider = GetComponent<MeshCollider>(); //get compponet of mesh collider

        if (collider == null)                    // if collider is null then add
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();     //create new mesh
        m_Line.BakeMesh(mesh);
        collider.sharedMesh = mesh;

    }
}
