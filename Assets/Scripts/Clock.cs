using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Header("Food per Tick")]
    [SerializeField] private int KnightConsume;
    [SerializeField] private int FarmerConsume;

    private float nextKnightEats, nextFarmEats;


    [Header("Ticks")]
    [SerializeField] private int FoodTick, ConsumeTick;
    [SerializeField] private int FoodPerTick;

    private float nextFoodTime;

    [Header("Timers")]
    [SerializeField] private int WaveComeIn;
    private float TimeUntillWave;


    [HideInInspector]
    public bool foodIsGrowing = true, waveTimerEnabled = true;

    private CounterControler counter;
    private UnitsController units;
    private Batler batler;
    private GameController game;

    void Start()
    {
        units = GetComponent<UnitsController>();
        counter = GetComponent<CounterControler>();
        batler = GetComponent<Batler>();
        game = GetComponent<GameController>();
        game.isPaused = false;
    }
    void Update()
    {

        if (!game.isPaused)
        {

            if (foodIsGrowing)
            {
                if (Time.time > nextFoodTime)
                {
                    nextFoodTime += FoodTick;
                    //Debug.Log("Adding " + (counter.FarmersAmmount * FoodPerTick) + " of food ( " + counter.FarmersAmmount + " farmers " + FoodPerTick + " food );");
                    counter.UpdateCounter("Food", (counter.FarmersAmmount * FoodPerTick));
                }

            }

            if (counter.KnightsAmount > 0)
            {
                if (Time.time > nextKnightEats)
                {
                    nextKnightEats += ConsumeTick;
                    counter.UpdateCounter("Food", (counter.KnightsAmount * KnightConsume) * -1);
                }
            }

            if (counter.FarmersAmmount > 0)
            {
                if (Time.time > nextFarmEats)
                {
                    nextFarmEats += ConsumeTick;
                    counter.UpdateCounter("Food", (counter.FarmersAmmount * FarmerConsume) * -1);
                }
            }

            if (waveTimerEnabled)
            {
                WaveTimer();
            }
        }

    }
    
    public void resetTimer()
    {
        TimeUntillWave = (WaveComeIn * batler.wave);
    }
    private void WaveTimer()
    {

        if (TimeUntillWave == 0)
        {
            TimeUntillWave = WaveComeIn * batler.wave;

        }



        if (TimeUntillWave > 0)
        {
            TimeUntillWave -= Time.deltaTime;

            counter.WaveComingIn.text = Mathf.Round(TimeUntillWave).ToString();

            return;
        }
        else
        {
            TimeUntillWave = 0;
            waveTimerEnabled = false;
            batler.Fight();
        }
    }


}
