using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Wave Won Menu")]
    [SerializeField] private GameObject waveWonMenu;
    [SerializeField] private Text knightsLeftText;
    [SerializeField] private Text wavesWon;

    [Header("Game Lost Menu")]
    [SerializeField] private GameObject gameLostMenu;
    [SerializeField] private Text knightsBought;
    [SerializeField] private Text FarmersBought;
    [SerializeField] private Text SkeletonsKilled;

    public GameObject SettingsMenuGroup;

    private GameController game;
    private CounterControler counter;
    private Batler batler;

    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<GameController>();
        counter = GetComponent<CounterControler>();
        batler = GetComponent<Batler>();
    }

    public void enableWaveWonMenu()
    {
        game.Paused();
        waveWonMenu.SetActive(true);
        knightsLeftText.text = counter.KnightsAmount.ToString();
        wavesWon.text = batler.wave.ToString();
        SettingsMenuGroup.SetActive(false);
    }
    public void closeWonMenu()
    {
        batler.InitWave();
        SettingsMenuGroup.SetActive(true);
        waveWonMenu.SetActive(false);
        game.Continue();
        
    }

    public void enableLostMenu()
    {
        game.Paused();
        gameLostMenu.SetActive(true);
        knightsBought.text = counter.KnightsHired.ToString();
        FarmersBought.text = counter.FarmerHired.ToString();
        SkeletonsKilled.text = counter.SkeletonKilled.ToString();
    }

    public void disableLostMenu()
    {
        game.Continue();
        gameLostMenu.SetActive(false);
       
    }
}
