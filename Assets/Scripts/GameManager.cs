using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private Gui m_gui;
    private EGameState m_gameStates = EGameState.STARTMENU;
	// Use this for initialization
	void Start () 
    {
        GameStates = EGameState.STARTMENU;
	}
	// Update is called once per frame
	void Update () 
    {
	
	}
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_gui = FindObjectOfType<Gui>();
      //  m_Instance = this;
    }
    public EGameState GameStates 
    { 
        get 
        {
            return m_gameStates;
        } 
        set 
        {
            switch (m_gameStates)
            {
                case EGameState.STARTMENU:
                    DeactivateStartMenu();
                    break;
                case EGameState.INGAME:
                    DeactivateIngame();
                    break;
                case EGameState.PAUSE:
                    DeactivatePause();
                    break;
                case EGameState.ITEMSHOP:
                    DeactivateItemShop();
                    break;
                case EGameState.OPTIONS:
                    DeactivateOptions();
                    break;
                case EGameState.ENDSCREEN:
                    DeactivateEndScreen();
                    break;
                default:
                    break;
            }
            switch (value)
            {
                case EGameState.STARTMENU:
                    ActivateStartMenu();
                    break;
                case EGameState.INGAME:
                    ActivateIngame();
                    break;
                case EGameState.PAUSE:
                    ActivatePause();
                    break;
                case EGameState.ITEMSHOP:
                    ActivateItemShop();
                    break;
                case EGameState.OPTIONS:
                    ActivateOptions();
                    break;
                case EGameState.ENDSCREEN:
                    ActivateEndScreen();
                    break;
                default:
                    break;
            }
            m_gameStates = value;
        } 
    }

    #region deactivate GameStates

    private void DeactivateStartMenu()
    {
        m_gui.StartMenu.SetActive(false);
      
    }

    private void DeactivateIngame()
    {
        m_gui.IngameUI.SetActive(false);   
    }

    private void DeactivatePause()
    {
        m_gui.PauseMenu.SetActive(false);
    }

    private void DeactivateItemShop()
    {
        m_gui.ItemShop.SetActive(false);
    }

    private void DeactivateOptions()
    {
       // m_gui.Options.SetActive(false);
    }

    private void DeactivateEndScreen()
    {
        m_gui.EndScreen.SetActive(false);
    }

    #endregion

    #region activate GameStates

    private void ActivateStartMenu()
    {
        m_gui.StartMenu.SetActive(true);   
    }

    private void ActivateIngame()
    {
        m_gui.IngameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    private void ActivatePause()
    {
        m_gui.PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ActivateItemShop()
    {
        m_gui.ItemShop.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ActivateOptions()
    {
       // m_gui.
    }

    private void ActivateEndScreen()
    {
        m_gui.EndScreen.SetActive(true);
    }
    //public static GameManager m_Instance;

    #endregion

}
 public enum EGameState
 {
     STARTMENU,
     INGAME,
     PAUSE,
     ITEMSHOP,
     OPTIONS,
     ENDSCREEN
 }

