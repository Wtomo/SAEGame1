using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {

	public int m_score = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	public void AddScore(int _points)
	{
		m_score += _points;
	}

	public bool CanBuy(int _price)
	{
		if(m_score >= _price)
		{
			m_score -= _price;
			return true;
		}
		else
		{
			return false;
		}
	}

	void OnGUI()
	{
		Rect pos = new Rect (Screen.width - 100f, 0, 100f, 50f);
		GUI.Button (pos, "Score: " + m_score);

		pos = new Rect (Screen.width - 50f, Screen.height - 50f, 50f, 50f);
		if(GUI.Button (pos, "kill"))
		{
			AddScore(100);
		}

		pos = new Rect (Screen.width - 100f, Screen.height - 50f, 50f, 50f);
		if(GUI.Button (pos, "Buy"))
		{
			CanBuy(1500);
		}
	}
}
