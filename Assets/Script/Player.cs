using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController m_CharacterController;
    [SerializeField] float m_MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * m_MovementSpeed * Time.deltaTime;
        float z = Input.GetAxisRaw("Vertical") * m_MovementSpeed * Time.deltaTime;

        m_CharacterController.Move(Vector3.right * x);
        m_CharacterController.Move(Vector3.forward * z);
    }
}
