using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batler : MonoBehaviour
{
    [HideInInspector] public int wave;
    private int skeletonsGenerated;

    private CounterControler counter;
    private UnitsController units;
    private Clock clock;
    private GameController game;
    // Start is called before the first frame update
    void Start()
    {
        units = GetComponent<UnitsController>();
        counter = GetComponent<CounterControler>();
        clock = GetComponent<Clock>();
        game = GetComponent<GameController>();

        InitWave();

    }

    public void InitWave()
    {
        wave++;
        clock.waveTimerEnabled = true;
        clock.resetTimer();

        skeletonsGenerated = (Random.Range(2 * wave, wave * 5));

        counter.UpdateCounter("Coming", skeletonsGenerated);

    }

    public void Fight()
    {
        clock.foodIsGrowing = false;
        // units.AddSkeletons(skeletonsGenerated);
        clock.waveTimerEnabled = false;

        

        postFight();
    }

    private void postFight()
    {
        if (skeletonsGenerated > counter.KnightsAmount)
        {
            game.Lost();
        }
        else
        {
            counter.KnightsKilled += (skeletonsGenerated);
            counter.SkeletonKilled += (counter.KnightsAmount);
            counter.UpdateCounter("Knight", skeletonsGenerated * -1);

            game.WaveWon();
        }
    }

    public void resetBatler()
    {
        wave = 1;
    }
}
