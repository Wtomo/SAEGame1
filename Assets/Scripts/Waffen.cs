using UnityEngine;
using System.Collections;

abstract public class Waffen : MonoBehaviour
{
	public int m_maxMagSize = 20;
	public int m_maxAmmoCapacity = 80;

	public float m_reloadTime = 3f;
	public float m_fireRate = 0.1f;
	public float m_bulletSpeed = 5000f;

	public bool m_isAutomatic;

	public GameObject m_bulletPrefab;


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
		m_currentAmmo = m_maxAmmoCapacity - m_maxMagSize;
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
			GameObject bullet = Instantiate(m_bulletPrefab, transform.position, transform.rotation) as GameObject;
			bullet.rigidbody.AddForce(transform.forward * m_bulletSpeed);
			Destroy(bullet, 3);

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

			return;
		}
		else
		{
			m_reloadTimeCounter = 0f;

			neededAmmo = m_maxMagSize - m_currentMag;

			if(m_currentAmmo >= neededAmmo)
			{
				m_currentMag += neededAmmo;
				m_currentAmmo -= neededAmmo;
			}
			else if (m_currentAmmo < neededAmmo)
			{
				m_currentMag += m_currentAmmo;
				m_currentAmmo = 0;
			}

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
