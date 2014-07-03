using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

    private CharacterController m_characterController;
    public float m_MovementSpeed = 5.0f;
    public float m_Gravity = 9.81f;
    public Waffen m_Weapon;
    public Camera m_CharacterCamera;
    public GameObject m_Crosshair;
    //Contains the RaycastHit info from the cursor to the world every frame
    public RaycastHit? m_CurrentAimResult {get; private set;}

	// Use this for initialization
	void Start () {
        m_characterController = GetComponent<CharacterController>();
        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Handle weapon inputs if a weapon is assigned
        if (m_Weapon != null)
        {
            if (Input.GetButtonDown("Fire"))
            {
                m_Weapon.ShootGun(true);
            }
            else if (Input.GetButtonUp("Fire"))
            {
                m_Weapon.ShootGun(false);
            }
            if (Input.GetButtonDown("Reload"))
            {
                m_Weapon.ReloadGun();
            }
        }
        //Get the movement direction
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        //Add the gravity to the movement
        movement.y = -m_Gravity;

        m_characterController.Move(movement * Time.deltaTime * m_MovementSpeed);
        
        //calculate the camera target position based on the mouse offset to the screen center
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x = (mousePosition.x - Screen.width * 0.5f) / Screen.width * 15.0f;
        mousePosition.z = (mousePosition.y - Screen.height * 0.5f) / Screen.height * 15.0f;
        mousePosition.y = 0;
        Vector3 camPos = transform.position + (Vector3.up - Vector3.forward) * 10.0f + mousePosition;           

        m_CharacterCamera.transform.position = Vector3.Lerp(m_CharacterCamera.transform.position, camPos, Mathf.Clamp(Time.deltaTime * 4.0f, 0f, 1f));

        //Calculate the camera forward direction
        Vector3 lookDirection = (transform.position + mousePosition - m_CharacterCamera.transform.position).normalized;
        m_CharacterCamera.transform.forward = Vector3.Lerp(m_CharacterCamera.transform.forward, lookDirection, Mathf.Clamp(Time.deltaTime * 4.0f, 0f, 1f));

        //Rotate the Character towards the cursor position
        m_CurrentAimResult = Utilities.CursorRayCast(m_CharacterCamera);
        if (m_CurrentAimResult.HasValue)
        {
            Vector3 hitPos = m_CurrentAimResult.Value.point;
            hitPos.y = transform.position.y;
            transform.forward = hitPos - transform.position;
            m_Crosshair.transform.position = hitPos + Vector3.up;
        }        
	}
}
