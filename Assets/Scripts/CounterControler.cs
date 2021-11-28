using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterControler : MonoBehaviour
{
    [SerializeField] private Text FoodCounter, SkeletonsCommingCounter;
    public Text WaveComingIn;
    [SerializeField] private TextMesh KnightsCounter, FarmerCounter, SkeletonsCounter;

    [Header("Prices")]
    public int KnightsPrice;
    public int FarmerPrice;

    [Header("Ammounts")]
    public int FarmersAmmount;
    public int KnightsAmount;
    public int SkeletonAmount;
    public int FoodAmount;

    [HideInInspector] public int SkeletonKilled, KnightsKilled, FoodFarmed, KnightsHired, FarmerHired;
    void Start()
    {
        FoodCounter.text = FoodAmount.ToString();
    }
    public void ResetCounters()
    {

        FarmersAmmount = 1;
        FarmerCounter.text = "1";
        FarmerHired = 0;

        FoodAmount = 1;
        FoodCounter.text = "1";


        KnightsAmount = 0;
        KnightsCounter.text = "0";
        KnightsKilled = 0;

        SkeletonAmount = 0;
        SkeletonKilled = 0;
        SkeletonsCounter.text = "0";
    }

    public void UpdateCounter(string toUpdate, int amount)
    {
        if (toUpdate == "Food")
        {
            FoodAmount += amount;

            if (FoodAmount > 0)
            {
                FoodCounter.text = FoodAmount.ToString();
                FoodFarmed += FoodAmount;
            }
            else
            {
                FoodAmount = 0;
                FoodCounter.text = FoodAmount.ToString();
            }

        }
        if (toUpdate == "Farmer")
        {

            FarmersAmmount += amount;
            FarmerHired += amount;
            FarmerCounter.text = FarmersAmmount.ToString();


        }
        if (toUpdate == "Knight")
        {
            KnightsAmount += amount;
            KnightsHired += amount;

            if (KnightsAmount > 0)
            {
                KnightsCounter.text = KnightsAmount.ToString();
            }
            else
            {
                KnightsAmount = 0;
                KnightsCounter.text = KnightsAmount.ToString();

            }

        }
        if (toUpdate == "Skeletons")
        {
            SkeletonAmount += amount;

            if (SkeletonAmount > 0)
            {
                SkeletonsCounter.text = SkeletonAmount.ToString();
            }
            else
            {
                SkeletonAmount = 0;
                SkeletonsCounter.text = SkeletonAmount.ToString();
            }
          
        }
        if(toUpdate == "Coming")
        {
            SkeletonsCommingCounter.text = amount.ToString();
        }
        if (toUpdate == "WaveTimer")
        {
            WaveComingIn.text = amount.ToString();
        }
    }

   
}
