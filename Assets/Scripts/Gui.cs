using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour
{
    public UIReferences m_References;

    private E_spawner m_eSpawner;

    public GameObject StartMenu;
    public GameObject IngameUI;
    public GameObject PauseMenu;
    public GameObject ItemShop;
    public GameObject EndScreen;
    public GameObject EnemyBox;

    public UITexture EnemyHPBar;

    public UITexture HPBar;
    public UILabel Points;
    public UILabel BuyPoints;
    public UILabel WeaponNameIcon;
    public UILabel Ammo;
    public UISprite WeaponIcon;
    public UISprite EnemyBossIcon;
    public string[] weaponNames;

    private UISprite m_CurrentWeaponSprite;
    private int m_currentAmmo = 57;
    private int m_maxAmmo = 200;
    private int selectedWeaponIcon = 0;
    private float m_currentHP = 1f;
    private float m_enemyCurrentHP = 1f;
    private float m_enemyMaxHP = 100f;
    private float m_maxHP = 100f;
    private float m_currentPoints = 10f;
    private float m_currentBuyPoint = 10f;
   // private bool m_testWeaponSwitch = true;
    private bool isPaused = false;
    private GameManager m_gameManager;

    void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
       // m_eSpawner = FindObjectOfType<E_spawner>();


        DontDestroyOnLoad(StartMenu);
        DontDestroyOnLoad(IngameUI);
        DontDestroyOnLoad(PauseMenu);
        DontDestroyOnLoad(ItemShop);
        DontDestroyOnLoad(EndScreen);
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        m_currentHP = m_maxHP;
        m_enemyCurrentHP = m_enemyMaxHP;
    }

    void Update()
    {
       // Debug.Log(m_gameManager.GameStates);
        CurrentPoints();
        Pause();
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
        m_gameManager.GameStates = EGameState.INGAME;
        //IngameUI.SetActive(true);
        //StartMenu.SetActive(false);
      //  GameManager.m_Instance.GameStates = EGameState.INGAME;

    }

    public void RestartMenu()
    {
        m_gameManager.GameStates = EGameState.STARTMENU;
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        for (int i = 0; i < allObjects.Length; i++ )
        {
            Destroy(allObjects[i]);
        }

        Screen.showCursor = true;
        Application.LoadLevel(0);
       // EndScreen.SetActive(false);
    }

    public void Pause()
    {
        //PauseMenu.SetActive(false);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
            isPaused = !isPaused;
            //Time.timeScale = isPaused ? 0:1;
            if (isPaused == false)
            {
                m_gameManager.GameStates = EGameState.INGAME;
                // IngameUI.SetActive(true);
                // PauseMenu.SetActive(false);
            }
            else
            { 
                m_gameManager.GameStates = EGameState.PAUSE;
            }
        }

    }

    public void Continue()
    {
        isPaused = !isPaused;
        m_gameManager.GameStates = EGameState.INGAME;
        //Time.timeScale = isPaused ? 0 : 1;
        // IngameUI.SetActive(true);
        // PauseMenu.SetActive(false);
    }

    

    public void Options()
    {
       
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EnemyHealth()
    {
        if (m_eSpawner.m_BossSpawned && !EnemyBox.activeSelf)
        {
            EnemyBox.SetActive(true);
        }
        
    }

    public void Endscreen()
    {
        m_gameManager.GameStates = EGameState.ENDSCREEN;
    }

    public void CurrentPoints()
    {
        Points.text = m_currentPoints.ToString();
        BuyPoints.text = m_currentBuyPoint.ToString();
    }

    public void ChangeIcon()
    {
        selectedWeaponIcon = (selectedWeaponIcon + 1) % weaponNames.Length;
        WeaponIcon.spriteName = weaponNames[selectedWeaponIcon];
        WeaponNameIcon.text = weaponNames[selectedWeaponIcon];
        Ammo.text = m_currentAmmo.ToString() + "/" + m_maxAmmo.ToString();        
    }

}

[System.Serializable]
public class UIReferences
{
    public UITexture m_HorstHP;
    public UISprite m_HorstWeapon;
    public UILabel m_HorstAmmo;
    public UILabel m_CurrentWave;
}

