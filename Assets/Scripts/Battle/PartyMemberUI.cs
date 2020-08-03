using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberUI : MonoBehaviour
{
    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private HPBar hpBar;

    [SerializeField]
    private Color highlightedColor;

    private Pokemon pokemon;

    public void SetData(Pokemon pokemon)
    {
        this.pokemon = pokemon;

        nameText.text = pokemon.PokemonBase.Name;
        levelText.text = "Lvl " + pokemon.Level;
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            nameText.color = highlightedColor;
        }
        else
        {
            nameText.color = Color.black;
        }
    }
}
