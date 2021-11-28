using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsControlelr : MonoBehaviour
{
    [Header("Units Buttons")]
    public Button farmerButton;
    public Button knightButton;
    public Button battleButton;



    private CounterControler counter;
    private UnitsController units;
    private Clock clock;
    private GameController game;
    void Start()
    {
        units = GetComponent<UnitsController>();
        counter = GetComponent<CounterControler>();
        clock = GetComponent<Clock>();
        game = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.isPaused)
        {
            battleButton.interactable = true;

            if (counter.FoodAmount < counter.FarmerPrice)
            {
                farmerButton.interactable = false;
            }
            else
            {
                farmerButton.interactable = true;
            }

            if (counter.FoodAmount < counter.KnightsPrice)
            {
                knightButton.interactable = false;
            }
            else
            {
                knightButton.interactable  = true;
            }
        }
        else
        {
            units.buttonsAreActive = false;
            farmerButton.interactable = false;
            knightButton.interactable = false;
            battleButton.interactable = false;

        }
    }

    public void EnableAll()
    {
        units.buttonsAreActive = true;
        farmerButton.interactable = true;
        knightButton.interactable = true;
    }

    public void pause()
    {

    }

    public void settingsMenu()
    {

    }

    public void mute()
    {

    }

    public void restart()
    {
        game.RestartGame();
    }
}
