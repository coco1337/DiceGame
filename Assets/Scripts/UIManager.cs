using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public sealed class UIManager : MonoBehaviour
{
    [SerializeField] private BlueMarbleManager bmm;

    [SerializeField] private TextMeshProUGUI txtDiceResult;


    public DiceManager diceManager;

    public TextMeshProUGUI valueText;


    public void PlayerMovePoint()
    {
        int diceToMove = diceManager.totalValue;
        valueText.text = diceToMove.ToString();
    }

    public void UpdateDiceResult(int d)
    {
        txtDiceResult.text = "result : " + d;
    }
}


