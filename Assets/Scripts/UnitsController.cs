using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsController : MonoBehaviour
{
    [HideInInspector]
    public bool buttonsAreActive = true;

    private CounterControler counter;
    private Clock clock;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<CounterControler>();
        clock = GetComponent<Clock>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddFarmer()
    {
        if (buttonsAreActive)
        {
            if (counter.FoodAmount >= counter.FarmerPrice)
            {
                counter.UpdateCounter("Farmer", 1);
                counter.UpdateCounter("Food", (counter.FarmerPrice * -1));

            }
            else
            {
                Debug.Log("Not enough of food");
            }

        }
    }

    public void AddKnight()
    {
        if (buttonsAreActive)
        {
            if (counter.FoodAmount >= counter.KnightsPrice)
            {
                counter.UpdateCounter("Knight", 1);
                counter.UpdateCounter("Food", (counter.KnightsPrice * -1));

            }
            else
            {
                Debug.Log("Not enough of food");
            }
        }

    }

    public void AddSkeletons(int amount)
    {
        if (buttonsAreActive)
        {
            if (counter.FoodAmount >= counter.KnightsPrice)
            {
                counter.UpdateCounter("Skeletons", amount);

            }
        }

    }
}
