using UnityEngine;
using System.Collections;


//Test charackter Controller
public class Move : MonoBehaviour 
{
    public float m_MoveSpeed = 5f;
    public float m_RotationSpeed = 70f;
    public float m_RunSpeedMultiplicator = Mathf.PI;
    public float m_JumpPower = 10f;
    public float m_Gravity = 9.81f;

    private float m_ySpeed = 0f;
    private CharacterController m_charController;

	// Use this for initialization
    // Use this for initialization
    void Start()
    {
        // Zwischencachen des Charcontrollers vermindert Rechenzeit
        m_charController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        ProcessMovement();
        ProcessRotation();
        
	
	}

    void ProcessMovement()
    {
        Vector3 move = new Vector3();
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * m_MoveSpeed;
        move.z = Input.GetAxis("Vertical") * Time.deltaTime * m_MoveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= m_RunSpeedMultiplicator;
        }

        // Gravity
        if (!m_charController.isGrounded)
        {
            m_ySpeed -= m_Gravity * Time.deltaTime;
        }
        else
        {
            m_ySpeed = -0.1f;
        }

        // Jump
        if (m_charController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_ySpeed = m_JumpPower;
            }
        }

        move.y = m_ySpeed;

        // Wandelt die Richtung von Weltkoordinaten in lokale Koordinanten um
        move = transform.TransformDirection(move);

        m_charController.Move(move);
    }

    void ProcessRotation()
    {
        float xRot = Input.GetAxis("Mouse X") * Time.deltaTime * m_RotationSpeed;
        transform.Rotate(Vector3.up, xRot);

    }
}
