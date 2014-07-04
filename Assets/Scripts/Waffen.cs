using UnityEngine;
using System.Collections;

public class Waffen : MonoBehaviour
{   
	public int m_maxMagSize = 20;

    public int m_bulletDamage = 5;
	public float m_reloadTime = 3f;
	public float m_fireRate = 0.1f;
	public float m_bulletSpeed = 50f;
    public float m_MuzzleFlashTime;

	public bool m_isAutomatic;
    public Transform m_WeaponPoint;

	public GameObject m_bulletPrefab;
    public GameObject m_muzzleFlash1;

	protected int m_currentMag;
	protected int m_currentAmmo;

	protected float m_fireRateCounter = 0f;
	protected float m_reloadTimeCounter = 0f;

	protected bool m_shoot = false;
	protected bool m_reload = false;

	// Use this for initialization
	protected void Start()
	{
		m_currentMag = m_maxMagSize;
		m_currentAmmo = m_maxMagSize;
	}
	
	// Update is called once per frame
	protected void Update()
	{
		if(m_reload)
		{
			Reload();
		}

		if(m_shoot && !m_reload)
		{
			Shoot();
		}
	}

	protected void Shoot()
	{
		if(m_fireRateCounter >= m_fireRate)
		{
			Bullet bullet = ((GameObject)Instantiate(m_bulletPrefab, m_WeaponPoint.position, m_WeaponPoint.rotation)).GetComponent<Bullet>();
            bullet.SetBulletspeed(m_bulletSpeed);
            bullet.SetDamage(m_bulletDamage);
            bullet.SetTarget(Bullet.BulletTarget.Enemy);

            GameObject muzzleFlash = Instantiate(m_muzzleFlash1, m_WeaponPoint.position, m_WeaponPoint.rotation) as GameObject;
            Destroy(muzzleFlash, m_MuzzleFlashTime);
			Destroy(bullet.gameObject, 3);

			m_currentMag -= 1;

			if(!m_isAutomatic)
			{
				m_shoot = false;
			}

			m_fireRateCounter = 0;
		}
		else
		{
			m_fireRateCounter += Time.deltaTime;
		}

		if(m_currentMag <= 0)
		{
			m_reload = true;
		}
	}

	protected void Reload()
	{
		int neededAmmo;

		if(m_reloadTimeCounter <= m_reloadTime)
		{
			m_reload = true;
			m_reloadTimeCounter += Time.deltaTime;
		}
		else
		{
			m_reloadTimeCounter = 0f;
            m_currentMag = m_maxMagSize;

			m_reload = false;
		}
	}

	public void ShootGun(bool _shoot)
	{
		if(_shoot)
		{
			m_shoot = true;
		}
		else if(!_shoot)
		{
			m_shoot = false;
		}
	}

	public void ReloadGun()
	{
		m_reload = true;
	}

	protected void OnGUI()
	{
		Rect pos = new Rect (0, 0, 50, 50);
		GUI.Button (pos, m_currentMag + "/" + m_currentAmmo);

		if(m_reload)
		{
			pos = new Rect (0, 50, 100, 50);
			GUI.Button (pos, "reloading");
		}
	}
}
