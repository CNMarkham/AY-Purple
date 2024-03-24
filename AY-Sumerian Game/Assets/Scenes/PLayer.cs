using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PLayer : MonoBehaviour
{
    public string playerName;
    private ulong highestPop;
    private GameplayManager gameManager;

    public TMP_Text nameText;
    public TMP_Text yearText;
    public TMP_Text highestPopText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "Ruler: " + playerName;

        gameManager = GetComponent<GameplayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        yearText.text = "Year: " + gameManager.year;

        if (gameManager.population > highestPop)
        {
            highestPop = gameManager.population;
            highestPopText.text = "Highest Population: " + highestPop;
        }
   
    



}
}
