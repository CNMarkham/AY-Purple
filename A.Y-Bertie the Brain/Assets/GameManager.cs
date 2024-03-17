using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool playerTurn = true;
    [SerializeField]
    private List<GameObject> buttons = new List<GameObject>();

    [SerializeField]
    private TMP_Text results;

    
    private string[,] items = new string[3,3];

    private int numOfTurns = 0;

    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        numOfTurns = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTurn && !gameOver)
        {
            GameObject button = buttons[Random.Range(0, buttons.Count - 1)];
            button.GetComponent<Button>().enabled = false;
            button.GetComponent<Image>().color = Color.blue;
            button.GetComponentInChildren<TMP_Text>().text = "O";
            int buttonNum = int.Parse(button.name[button.name.Length - 1].ToString());
            items[buttonNum / 3, buttonNum % 3] = "O";
            buttons.Remove(button);
            playerTurn = true;
            CheckForWin("O");
        }
    }

    public void ButtonClicked(GameObject button)
    {
        if (!playerTurn || gameOver)
            return;

        button.GetComponent<Button>().enabled = false;
        button.GetComponent<Image>().color = Color.red;
        button.GetComponentInChildren<TMP_Text>().text = "X";
        int buttonNum = int.Parse(button.name[button.name.Length-1].ToString());
        items[buttonNum / 3, buttonNum % 3] = "X";
        buttons.Remove(button);
        playerTurn = false;
        CheckForWin("X");
    }

    private void CheckForWin(string letter)
    {
        //Vertical Win
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (items[x, y] != letter)
                    break;
                if (y == 2)
                {
                    DisplayWinner(letter);
                }
            }
        }

        //Horizontal Win
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (items[x, y] != letter)
                    break;
                if (x == 2)
                {
                    DisplayWinner(letter);
                    return;
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (items[i, i] != letter)
                break;
            if (i == 2)
            {
                DisplayWinner(letter);
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (items[i, 2 - i] != letter)
                break;
            if (i == 2)
            {
                DisplayWinner(letter);
                return;
            }
        }
        numOfTurns++;
        if (numOfTurns == 9 && !gameOver)
        {
            results.text = "Draw";
            gameOver = true;
        }
    }

    private void DisplayWinner(string letter)
    {
        if (letter == "X")
        {
            results.text = "Player \n Wins!";
        }
        else
        {
            results.text = "Bertie \n Wins!";
        }
        gameOver = true;
    }
}
