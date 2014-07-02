using UnityEngine;
using System.Collections;

public class Ufo_move : MonoBehaviour {

    public Transform[] _waypoints;
    private float _speed = 25f;
    private int i = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}
    void Move()
    {
        Vector3 dis = _waypoints[i].position - transform.position;
        Vector3 dir = dis.normalized * Time.deltaTime * _speed;
        if (dir.sqrMagnitude > dis.sqrMagnitude)
        {
            transform.position = _waypoints[i].position;
            i = (i + 1) % _waypoints.Length;
        }
        transform.Translate(dir);
    }
}
