using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

    private CharacterController m_characterController;
    public float m_MovementSpeed = 5.0f;
    public Camera m_CharacterCamera;

	// Use this for initialization
	void Start () {
        m_characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;
	    if(Input.GetKey(KeyCode.A))
        {
            movement.x -= 1.0f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movement.x += 1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.z += 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= 1.0f;
        }

        if(movement.sqrMagnitude > 0)
        {
            m_characterController.Move(movement * Time.deltaTime * m_MovementSpeed);
        }

        if(m_CharacterCamera != null)
        {
            m_CharacterCamera.transform.position = Vector3.Lerp(m_CharacterCamera.transform.position, transform.position + (Vector3.up - Vector3.forward) * 10.0f, Time.deltaTime * 2.0f);
            m_CharacterCamera.transform.forward = Vector3.Lerp(m_CharacterCamera.transform.forward, (transform.position - m_CharacterCamera.transform.position).normalized, Time.deltaTime * 2.0f);
        }
	}
}
