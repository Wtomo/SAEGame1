using UnityEngine;
using System.Collections;

public class RandomDrops : MonoBehaviour
{
	public GameObject[] m_Items;
	public int[] m_SpawnPercentage;

	public float m_LifeTime = 3f;
	
	private float m_TimeAlive = 0f;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		m_TimeAlive += Time.deltaTime;

		if(m_TimeAlive >= m_LifeTime)
		{
			DropRandomItem();
			Destroy(gameObject);
		}
	}

	void DropRandomItem()
	{
		int randomDrop;
		int counter = 0;

		System.Random rng = new System.Random();

		randomDrop = rng.Next(0, 100);

		for(int i = 0; i <= m_Items.Length - 1; i++)
		{
			if(randomDrop >= counter && randomDrop <= counter + m_SpawnPercentage[i])
			{
				Instantiate(m_Items[i], transform.position, transform.rotation);
				return;
			}

			counter += m_SpawnPercentage[i];
		}
	}
}
