using UnityEngine;
using System.Collections;

public class E_spawner : MonoBehaviour {
    //6 féle enemy
    public static int _EnemyCounter=0;
    public Transform[] _spawnpoints;
    public GameObject[] _enemyClassA;
    public GameObject[] _enemyClassB;
    public GameObject[] _enemyClassC;
    private bool _nextWave = false;
    private int _wavePoints = 10;
    private int _costA = 1;
    private int _costB = 3;
    private int _costC = 5;
    private int _waveCounter = 0;
    private int rnd;
    private int rndEnemy;
    private int rndPosition;
    private float timer = 2f;
	// Use this for initialization
	void Start () 
    {
        //Debug.Log(_enemyClassA.Length);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer();
        waveCheck();
	    if (_nextWave && timer<0)
        {
            waveSpawner();
        }
	}
        void waveCheck()
        {
            if (_EnemyCounter<=0)
            {
                _nextWave = true;
            }
        }
    void waveSpawner()
        {

        //_wavepoints check; which enemy pool available + random select a pool
            if (_wavePoints>=_costC)
            {
                rnd = Random.Range(1, 4);
            }
            else
            {
                if (_wavePoints>=_costB)
                {
                     rnd = Random.Range(1, 3);
                }
                else
                {
                    if (_wavePoints>=_costA)
                     {
                     rnd = 1;
                     }
                    else
                    {
                        rnd = 0;
                    }
                }
            }
        //select random enemy in Pool A,B or C 
        rndEnemy = Random.Range(0, _enemyClassA.Length);
        //select random ufo for spawn position
        rndPosition= Random.Range(0,_spawnpoints.Length);

        //check the random pool and spawn enemy
        switch (rnd)
        {
            case 1:
            {
                Debug.Log("A pool");
                Instantiate(_enemyClassA[rndEnemy], _spawnpoints[rndPosition].position, Quaternion.identity);
                timer = 2f;
                _EnemyCounter++;
                _wavePoints-=_costA;
                break;
            }
            case 2:
            {
                Debug.Log("B pool");
                Instantiate(_enemyClassB[rndEnemy], _spawnpoints[rndPosition].position, Quaternion.identity);
                timer = 2f;
                _EnemyCounter++;
                _wavePoints -= _costB;
                break;
            }
            case 3:
            {
                Debug.Log("C pool");
                Instantiate(_enemyClassC[rndEnemy], _spawnpoints[rndPosition].position, Quaternion.identity);
                timer = 2f;
                _EnemyCounter++;
                _wavePoints -= _costC;
                break;
            }

        }
        //point check, prepare for next wave
        if (_wavePoints==0)
        {
            _nextWave = false;
            _waveCounter++;
            _wavePoints = 10 + (_waveCounter * 5);
            Debug.Log("Enemy Count: " + _EnemyCounter);
            Debug.Log("Computer Points: "+ _wavePoints);
            Debug.Log("Status: " + _nextWave);
            Debug.Log("Wave " + _waveCounter + " End!!");

        }

        }
    void Timer()
    {
        //delay for spawns
        timer -= Time.deltaTime;              
    }
}
