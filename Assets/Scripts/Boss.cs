using UnityEngine;
using System.Collections;

public class Boss : Enemyclass
{
	public GameObject m_Body;
	public GameObject m_LeftCannon;
	public GameObject m_RightCannon;
	public GameObject m_BulletPrefab;
	
	
	private float m_counter = 0;
	
	// Use this for initialization
	protected override void ProcessMove()
	{
		m_minRange = 3f;   
		base.ProcessMove(); 
	}
	
	protected override void ProcessAttack()
	{
		m_HP = 100;

		if(m_HP > 80)
		{
			ShootPattern(500f, 0.2f, 1.5f, Color.green);
		}
		else if(m_HP > 60)
		{
			ShootPattern(760f, 0.08f, 0.8f, Color.blue);
		}
		else if(m_HP > 30)
		{
			ShootPattern(200f, 0.04f, 0.7f, Color.yellow);
		}
		else if(m_HP > 0)
		{
			ShootPattern(850f, 0.01f, 0.9f, Color.red);
		}
		else if(m_HP <= 0)
		{
			return;
		}
		
	}
	
	void ShootPattern(float _rotationSpeed, float _fireRate, float _lifeTime, Color _color)
	{
		//m_LeftCannon.renderer.material.color = _color;
		//m_RightCannon.renderer.material.color = _color;
		
		m_Body.transform.Rotate(new Vector3(0, 1, 0) * _rotationSpeed * Time.deltaTime);
		
		if(m_counter >= _fireRate)
		{
			GameObject bulletLeft = Instantiate(m_BulletPrefab, m_LeftCannon.transform.position, m_LeftCannon.transform.rotation) as GameObject;
			bulletLeft.renderer.material.color = _color;
			bulletLeft.rigidbody.AddForce(m_LeftCannon.transform.forward * 100);
			Destroy(bulletLeft, _lifeTime);
			
			GameObject bulletRight = Instantiate(m_BulletPrefab, m_RightCannon.transform.position, m_RightCannon.transform.rotation) as GameObject;
			bulletRight.renderer.material.color = _color;
			bulletRight.rigidbody.AddForce(m_RightCannon.transform.forward * 100);
			Destroy(bulletRight, _lifeTime);
			
			m_counter = 0f;
		}
		m_counter += Time.deltaTime;
	}
}