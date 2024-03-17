using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public ulong foodGrain;
    public ulong plantingGrain;
    public ulong storageGrain;
    public ulong usableGrain;
    public ulong population;
    public int year;

    public TMP_Text mainText;
    public TMP_InputField foodGrainInput;
    public TMP_InputField plantingGrainInput;
    public TMP_InputField storageGrainInput;

    enum RandomEvents { Flood, Locusts, Fire};
    // Start is called before the first frame update
    void Start()
    {
        mainText.text = "Welcome to the Sumerian Game. Your goal is to manage the grain supply for your city and grow it to the largest population possible." +
            "You have 5000 grain to start and a population of 500";
        StartCoroutine("Year");
        usableGrain = 5000;
        population = 500;
        year = 0;
    }

    private IEnumerator Year()
    {
        yield return new WaitForSeconds(1f);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }

        if (foodGrainInput.text == "" ||
            plantingGrainInput.text == "" ||
            storageGrainInput.text == "")
        {
            string text = mainText.text;
            mainText.text = "Make sure each number is greater than 0";
            yield return new WaitForSeconds(2f);
            mainText.text = text;
            StartCoroutine("Year");
            yield break;
        }

        foodGrain = ulong.Parse(foodGrainInput.text);
        plantingGrain = ulong.Parse(plantingGrainInput.text);
        storageGrain = ulong.Parse(storageGrainInput.text);
        if (foodGrain < 0 || plantingGrain < 0 || storageGrain < 0)
        {
            string text = mainText.text;
            mainText.text = "Make sure each number is greater than 0";
            yield return new WaitForSeconds(2f);
            mainText.text = text;
            StartCoroutine("Year");
            yield break;
        }

        if (foodGrain + plantingGrain + storageGrain > usableGrain)
        {
            string text = mainText.text;
            mainText.text = "You have allocated more grain than you have.";
            yield return new WaitForSeconds(2f);
            mainText.text = text;
            StartCoroutine("Year");
            yield break;
        }

        int randEvent = Random.Range(0, 8);
        switch (randEvent)
        {
            case (int)RandomEvents.Flood:
                if (population <= foodGrain)
                {
                    population = (ulong)Mathf.Round(population * 1.2f);
                } else
                {
                    population = foodGrain;
                }
                plantingGrain = (ulong)Mathf.Round(plantingGrain / 4);
                usableGrain = plantingGrain + storageGrain;
                plantingGrain = 0;
                storageGrain = 0;
                foodGrain = 0;
                if (population <= 0 || usableGrain == 0)
                {
                    mainText.text = "Game Over.";
                    yield break;
                }
                mainText.text = $"There was a terrible flood, ruining much of the planted crops for the year." +
                    $"You have {usableGrain} amount of grain. Your population is {population}.";
                break;
            case (int)RandomEvents.Locusts:
                if (population <= foodGrain)
                {
                    population = (ulong)Mathf.Round(population * 1.2f);
                }
                else
                {
                    population = foodGrain;
                }
                storageGrain = (ulong)Mathf.Round(storageGrain / 3);
                plantingGrain = (ulong)Mathf.Round(plantingGrain * 1.4f);
                usableGrain = plantingGrain + storageGrain;
                plantingGrain = 0;
                storageGrain = 0;
                foodGrain = 0;
                if (population <= 0 || usableGrain == 0)
                {
                    mainText.text = "Game Over.";
                    yield break;
                }
                mainText.text = $"Locusts infested your storage of grain, ruining much of it." +
                    $"You have {usableGrain} amount of grain. Your population is {population}.";
                break;
            case (int)RandomEvents.Fire:
                population = (ulong)Mathf.Round(population * 0.7f);
                if (population <= foodGrain)
                {
                    population = (ulong)Mathf.Round(population * 1.2f);
                }
                else
                {
                    population = foodGrain;
                }
                plantingGrain = (ulong)Mathf.Round(plantingGrain * 1.4f);
                usableGrain = plantingGrain + storageGrain;
                plantingGrain = 0;
                storageGrain = 0;
                foodGrain = 0;
                if (population <= 0 || usableGrain == 0)
                {
                    mainText.text = "Game Over.";
                    yield break;
                }
                mainText.text = $"Fire has spread throughout the city, killing a large portion of your population." +
                    $"You have {usableGrain} amount of grain. Your population is {population}.";
                break;
            default:
                Debug.Log(foodGrain);
                if (population <= foodGrain)
                {
                    population = (ulong)Mathf.Round(population * 1.2f);
                }
                else
                {
                    population = foodGrain;
                }
                plantingGrain = (ulong)Mathf.Round(plantingGrain * 1.4f);
                usableGrain = plantingGrain + storageGrain;
                plantingGrain = 0;
                storageGrain = 0;
                foodGrain = 0;
                if (population <= 0 || usableGrain == 0)
                {
                    mainText.text = "Game Over.";
                    yield break;
                }
                mainText.text = $"It has been a quiet season. Thank the gods all has gone well." +
                    $"You have {usableGrain} amount of grain. Your population is {population}.";
                break;
        }
        foodGrainInput.text = "0";
        plantingGrainInput.text = "0";
        storageGrainInput.text = "0";
        year++;
        StartCoroutine("Year");
        yield break;
    }
}
