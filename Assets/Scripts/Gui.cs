using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject IngameUI;
    public GameObject PauseMenu;
    public GameObject ItemShop;
    public GameObject EndScreen;

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
    }

    void Start()
    {
        m_currentHP = m_maxHP;
        m_enemyCurrentHP = m_enemyMaxHP;
    }

    void Update()
    {
        HPLoss();
        EnemyHPLoss();
        CurrentPoints();
        Pause();
    }

    public void StartGame()
    {
        //Application.LoadLevelAdditive(1);
        m_gameManager.GameStates = EGameState.INGAME;
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

    public void EnemyHPLoss()
    {
        EnemyHPBar.width = (int)(550 * m_enemyCurrentHP / m_enemyMaxHP);
    }
    public void HPLoss()
    {
        HPBar.width = (int)(135 * m_currentHP / m_maxHP);
    }

    public void CurrentPoints()
    {
        Points.text = m_currentPoints.ToString();
        BuyPoints.text = m_currentBuyPoint.ToString();
    }

    public void HPDamage()
    {
        m_enemyCurrentHP = m_enemyCurrentHP - 1;
    }

    public void ChangeIcon()
    {
        selectedWeaponIcon = (selectedWeaponIcon + 1) % weaponNames.Length;
        WeaponIcon.spriteName = weaponNames[selectedWeaponIcon];
        WeaponNameIcon.text = weaponNames[selectedWeaponIcon];
        Ammo.text = m_currentAmmo.ToString() + "/" + m_maxAmmo.ToString();        
    }
}



