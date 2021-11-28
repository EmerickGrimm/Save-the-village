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


    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Menu>();
        buttons = GetComponent<ButtonsControlelr>();
        batler = GetComponent<Batler>();
        clock = GetComponent<Clock>();
        counter = GetComponent<CounterControler>();
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
        isPaused = true;
        clock.foodIsGrowing = false;
        clock.waveTimerEnabled = false;
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
        isPaused = true;
        counter.ResetCounters();
        clock.resetTimer();
        batler.resetBatler();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
