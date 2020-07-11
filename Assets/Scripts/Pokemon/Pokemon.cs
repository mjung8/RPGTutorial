using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase PokemonBase { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase pokemonBase, int level)
    {
        this.PokemonBase = pokemonBase;
        this.Level = level;
        HP = MaxHp;

        // Generate moves
        Moves = new List<Move>();
        foreach (var move in pokemonBase.LearnableMoves)
        {
            if (move.Level <= level)
                Moves.Add(new Move(move.MoveBase));

            if (Moves.Count >= 4)
                break;
        }

    }

    public int Attack
    {
        get { return Mathf.FloorToInt((PokemonBase.Attack * Level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((PokemonBase.Defense * Level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((PokemonBase.SpAttack * Level) / 100f) + 5; }
    }

    public int SpDefense
    {
        get { return Mathf.FloorToInt((PokemonBase.SpDefense * Level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((PokemonBase.Speed * Level) / 100f) + 5; }
    }

    public int MaxHp
    {
        get { return Mathf.FloorToInt((PokemonBase.MaxHp * Level) / 100f) + 10; }
    }

    public bool TakeDamage(Move move, Pokemon attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.MoveBase.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }

        return false;
    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);

        return Moves[r];
    }
}
