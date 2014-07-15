using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMotor : CharacterMechanics {

    private CharacterController m_characterController;
    public float m_Gravity = 9.81f;

    public Transform m_HandPosition;
    public WeaponType m_SelectedWeapon{get; private set;}
    private Waffen m_Weapon;
    public Camera m_CharacterCamera;
    public Texture m_Crosshair;
    //Contains the RaycastHit info from the cursor to the world every frame
    public RaycastHit? m_CurrentAimResult {get; private set;}

    public GameObject m_DesertEaglePrefab;
    public GameObject m_ShotgunPrefab;
    public GameObject m_AssaultRiflePrefab;
    public GameObject m_LMGPrefab;

    public Vector3 m_CamOffset;
    public float m_CamSpeed;

    private Animator m_animator;

    public enum WeaponType
    {
        None,
        DesertEagle,
        Shotgun,
        AssaultRifle,
        LMG
    }

    private Dictionary<WeaponType, GameObject> m_availableWeapons;

    public void giveWeapon(WeaponType weaponType)
    {
        if(m_SelectedWeapon != WeaponType.None)
        {
            Destroy(m_Weapon.gameObject);
            m_SelectedWeapon = weaponType;
        }
        if (weaponType != WeaponType.None)
        {
            m_Weapon = ((GameObject)Instantiate(m_availableWeapons[weaponType], m_HandPosition.position, m_HandPosition.rotation)).GetComponent<Waffen>();
            m_Weapon.transform.parent = m_HandPosition;
            Debug.Log(m_Weapon);
        }
    }

	// Use this for initialization
	protected override void Start () {
        base.Start();
        m_characterController = GetComponent<CharacterController>();
        m_availableWeapons = new Dictionary<WeaponType, GameObject>() { 
            {WeaponType.DesertEagle, m_DesertEaglePrefab},
            {WeaponType.Shotgun, m_ShotgunPrefab},
            {WeaponType.AssaultRifle, m_AssaultRiflePrefab},
            {WeaponType.LMG, m_LMGPrefab}
        };
        m_SelectedWeapon = WeaponType.None;
        giveWeapon(WeaponType.DesertEagle);
        m_CharacterCamera.transform.forward = -m_CamOffset;
        Screen.showCursor = false;
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected override void Update () {
        m_animator.SetBool("Death", !m_IsAlive);
        if (!m_IsAlive) { return; }
        base.Update();
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        m_animator.SetFloat("Speed", Vector3.Dot(movement, transform.forward));
        movement.Normalize();
        //Add the gravity to the movement
        movement.y = -m_Gravity;

        m_characterController.Move(movement * Time.deltaTime * m_Speed);
        
        //calculate the camera target position based on the mouse offset to the screen center
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x = (mousePosition.x - Screen.width * 0.5f) / Screen.width * 15.0f;
        mousePosition.z = (mousePosition.y - Screen.height * 0.5f) / Screen.height * 15.0f;
        mousePosition.y = 0;
        Vector3 camPos = transform.position + m_CamOffset + mousePosition;           
                
        m_CharacterCamera.transform.position = Vector3.Lerp(m_CharacterCamera.transform.position, camPos, Mathf.Clamp(Time.deltaTime * m_CamSpeed, 0f, 1f));        

        //Rotate the Character towards the cursor position
        m_CurrentAimResult = Utilities.CursorRayCast(m_CharacterCamera);
        if (m_CurrentAimResult.HasValue)
        {
            Vector3 hitPos = m_CurrentAimResult.Value.point;
            hitPos.y = transform.position.y;
            transform.forward = hitPos - transform.position;
        }        
	}

    void OnGUI()
    {
        if (m_CurrentAimResult.HasValue)
        {
            Vector3 hitPoint = m_CurrentAimResult.Value.point;
            hitPoint.y = transform.position.y;
            Vector3 viewportAim = m_CharacterCamera.WorldToScreenPoint(hitPoint + Vector3.up);
            GUI.DrawTexture(new Rect(viewportAim.x - 50f, Screen.height - viewportAim.y - 50f, 100f, 100f), m_Crosshair, ScaleMode.ScaleToFit, true);
        }
    }
}
