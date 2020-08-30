using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private HPBar hpBar;

    private Pokemon pokemon;

    public void SetData(Pokemon pokemon)
    {
        this.pokemon = pokemon;

        nameText.text = pokemon.PokemonBase.Name;
        levelText.text = "Lvl " + pokemon.Level;
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp);
    }

    public IEnumerator UpdateHP()
    {
        if (pokemon.HpChanged)
        {
            yield return hpBar.SetHPSmooth((float)pokemon.HP / pokemon.MaxHp);
            pokemon.HpChanged = false;
        }

    }
}
