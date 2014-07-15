using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class E_spawner : MonoBehaviour {
    public static int _EnemyCounter=0;
    public List<Enemy_base> enemyclasses;
    public Transform[] _spawnpoints;
    public GameObject _boss;
    public Transform _bosspawnpoint;
    //public GameObject[] _enemyClassA;
   // public GameObject[] _enemyClassB;
   // public GameObject[] _enemyClassC;
    private bool _nextWave = false;
    private int _wavePoints = 10;
  //  private int _costA = 1;
   // private int _costB = 3;
  //  private int _costC = 5;
    private int _waveCounter = 1;
    public int _wavesperboss = 5;
    //private int rnd;
    //private int rndEnemy;
    //private int rndPosition;
    private float timer = 2f;
	// Use this for initialization
	void Start () 
    {
        //
        List<Enemy_base> spawn = new List<Enemy_base>();
        //spawn[0]._cost = 20;
        //
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
                _EnemyCounter = 0;
                _nextWave = true;
            }
        }
    void waveSpawner()
    {

        //_wavepoints check; which enemy pool available + random select a pool
            List<Enemy_base> ebl = enemyclasses.Where(o => o._cost <= _wavePoints).ToList();
        if (ebl.Count != 0)
            {
                Enemy_base eb = ebl[Random.Range(0, ebl.Count)];
                GameObject enemyToSpawn = eb._enemys[Random.Range(0, eb._enemys.Length)];
                Transform rndPosition = _spawnpoints[Random.Range(0, _spawnpoints.Length)];

                Debug.Log(eb._enemyName + " "+ eb._cost);
                Instantiate(enemyToSpawn, rndPosition.position, Quaternion.identity);
                timer = 2f;
                _EnemyCounter++;
                _wavePoints -= eb._cost;
            }
            else
            {
                _nextWave = false;
                _wavePoints = 10 + (_waveCounter * 5);
                if (_waveCounter % _wavesperboss ==0)
                {
                    SpawnBoss();
                }
                _waveCounter++;
                Debug.Log("Enemy Count: " + _EnemyCounter);
                Debug.Log("Computer Points: " + _wavePoints);
                Debug.Log("Status: " + _nextWave);
                Debug.Log("Wave " + _waveCounter + " End!!");
            }

           /* if (_wavePoints>=_costC)
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
            }*/

        //select random enemy in Pool A,B or C 
        
        //rndEnemy = Random.Range(0, _enemyClassA.Length);
        //select random ufo for spawn position
        //rndPosition= Random.Range(0,_spawnpoints.Length);

        //check the random pool and spawn enemy
        /*switch (rnd)
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

        }*/
        //point check, prepare for next wave
        /*if (_wavePoints==0)
        {
            _nextWave = false;
            _waveCounter++;
            _wavePoints = 10 + (_waveCounter * 5);
            Debug.Log("Enemy Count: " + _EnemyCounter);
            Debug.Log("Computer Points: "+ _wavePoints);
            Debug.Log("Status: " + _nextWave);
            Debug.Log("Wave " + _waveCounter + " End!!");

        }*/

    }

    private void SpawnBoss()
    {
       Instantiate(_boss,_bosspawnpoint.position,Quaternion.identity);
    }
    void Timer()
    {
        //delay for spawns
        timer -= Time.deltaTime;              
    }
}
