﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField]
    private int lettersPerSecond;

    [SerializeField]
    private Color highlightedColor;

    [SerializeField]
    private Text dialogText;

    [SerializeField]
    private GameObject actionSelector;

    [SerializeField]
    private GameObject moveSelector;

    [SerializeField]
    private GameObject moveDetails;

    [SerializeField]
    private List<Text> actionTexts;

    [SerializeField]
    private List<Text> moveTexts;

    [SerializeField]
    private Text ppText;

    [SerializeField]
    private Text typeText;


    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        yield return new WaitForSeconds(1f);
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for (int i = 0; i < actionTexts.Count; i++)
        {
            if (i == selectedAction)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }
    }

    public void UpdateMoveSelection(int selectedMove, Move move)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (i == selectedMove)
                moveTexts[i].color = highlightedColor;
            else
                moveTexts[i].color = Color.black;
        }

        ppText.text = $"PP {move.PP}/{move.MoveBase.PP}";
        typeText.text = move.MoveBase.Type.ToString();
    }

    public void SetMoveNames(List<Move> moves)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (i < moves.Count)
                moveTexts[i].text = moves[i].MoveBase.Name;
            else
                moveTexts[i].text = "-";
        }
    }

}
