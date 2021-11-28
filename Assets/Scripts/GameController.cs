using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{


    private Batler batler;
    private Clock clock;
    private CounterControler counter;
    private ButtonsControlelr buttons;
    private Menu menu;

    [HideInInspector] public bool isPaused;

    [SerializeField]
    private GameObject pausedUI;


    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Menu>();
        buttons = GetComponent<ButtonsControlelr>();
        batler = GetComponent<Batler>();
        clock = GetComponent<Clock>();
        counter = GetComponent<CounterControler>();

        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Lost()
    {
        menu.enableLostMenu();
    }

    public void WaveWon()
    {
        menu.enableWaveWonMenu();

    }

    public void Paused()
    {
        if (!isPaused)
        {
            isPaused = true;
            clock.foodIsGrowing = false;
            clock.waveTimerEnabled = false;
            pausedUI.SetActive(true);
        }
        else
        {
            isPaused = false;
            clock.foodIsGrowing = true;
            clock.waveTimerEnabled = true;
            pausedUI.SetActive(false);

        }

    }

    public void Continue()
    {
       
        buttons.EnableAll();
        isPaused = false;
        clock.foodIsGrowing = true;
        clock.waveTimerEnabled = true;
    }

    public void RestartGame()
    {
        Paused();
        counter.ResetCounters();
        clock.resetTimer();
        batler.resetBatler();
        Paused();
    }

}
