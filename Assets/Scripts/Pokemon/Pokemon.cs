using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pokemon
{
    [SerializeField]
    private PokemonBase pokemonBase;

    [SerializeField]
    private int level;

    public PokemonBase PokemonBase { get => pokemonBase; }

    public int Level { get => level; }

    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Dictionary<Stat, int> Stats { get; private set; }

    // pokemon moves can be boosted 6 levels so -6 to +6
    public Dictionary<Stat, int> StatBoosts { get; private set; }

    public Queue<string> StatusChanges { get; private set; } = new Queue<string>();

    public void Init()
    {
        // Generate moves
        Moves = new List<Move>();
        foreach (var move in pokemonBase.LearnableMoves)
        {
            if (move.Level <= level)
                Moves.Add(new Move(move.MoveBase));

            if (Moves.Count >= 4)
                break;
        }

        CalculateStats();

        HP = MaxHp;
        
        ResetStatBoost();
    }

    private void CalculateStats()
    {
        Stats = new Dictionary<Stat, int>();
        Stats.Add(Stat.Attack, Mathf.FloorToInt((PokemonBase.Attack * Level) / 100f) + 5);
        Stats.Add(Stat.Defense, Mathf.FloorToInt((PokemonBase.Defense * Level) / 100f) + 5);
        Stats.Add(Stat.SpAttack, Mathf.FloorToInt((PokemonBase.SpAttack * Level) / 100f) + 5);
        Stats.Add(Stat.SpDefense, Mathf.FloorToInt((PokemonBase.SpDefense * Level) / 100f) + 5);
        Stats.Add(Stat.Speed, Mathf.FloorToInt((PokemonBase.Speed * Level) / 100f) + 5);

        MaxHp = Mathf.FloorToInt((PokemonBase.MaxHp * Level) / 100f) + 10;
    }

    private void ResetStatBoost()
    {
        StatBoosts = new Dictionary<Stat, int>()
        {
            {Stat.Attack, 0},
            {Stat.Defense, 0},
            {Stat.SpAttack, 0},
            {Stat.SpDefense, 0},
            {Stat.Speed, 0},
        };
    }

    private int GetStat(Stat stat)
    {
        int statVal = Stats[stat];

        // Apply stat boost
        int boost = StatBoosts[stat];
        var boostValues = new float[] { 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f };

        if (boost >= 0)
            statVal = Mathf.FloorToInt(statVal * boostValues[boost]);
        else
            statVal = Mathf.FloorToInt(statVal / boostValues[-boost]);

        return statVal;
    }

    public void ApplyBoosts(List<StatBoost> statBoosts)
    {
        foreach (var statBoost in statBoosts)
        {
            var stat = statBoost.stat;
            var boost = statBoost.boost;

            StatBoosts[stat] = Mathf.Clamp(StatBoosts[stat] + boost, -6, 6);

            if (boost > 0)
                StatusChanges.Enqueue($"{pokemonBase.Name}'s {stat} rose!");
            else
                StatusChanges.Enqueue($"{pokemonBase.Name}'s {stat} fell!");

            Debug.Log($"{stat} has been boosted to {StatBoosts[stat]}");
        }
    }

    public int Attack { get => GetStat(Stat.Attack); }

    public int Defense { get => GetStat(Stat.Defense); }

    public int SpAttack { get => GetStat(Stat.SpAttack); }

    public int SpDefense { get => GetStat(Stat.SpDefense); }

    public int Speed { get => GetStat(Stat.Speed); }

    public int MaxHp { get; private set; }

    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        float criticalEffect = 1f;
        if (Random.value * 100f <= 6.25)
            criticalEffect = 2f;

        float typeEffect =
            TypeChart.GetEffectiveness(move.MoveBase.Type, this.PokemonBase.Type1) *
            TypeChart.GetEffectiveness(move.MoveBase.Type, this.PokemonBase.Type2);

        var damageDetails = new DamageDetails()
        {
            TypeEffect = typeEffect,
            CriticalEffect = criticalEffect,
            Fainted = false
        };

        float attack = (move.MoveBase.Category == MoveCategory.Special) ? attacker.SpAttack : attacker.Attack;
        float defense = (move.MoveBase.Category == MoveCategory.Special) ? SpDefense : Defense;

        float modifiers = Random.Range(0.85f, 1f) * typeEffect * criticalEffect;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.MoveBase.Power * ((float)attack / defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        }

        return damageDetails;
    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);

        return Moves[r];
    }

    public void OnBattleOver()
    {
        ResetStatBoost();
    }
}

public class DamageDetails
{
    public bool Fainted { get; set; }

    public float CriticalEffect { get; set; }

    public float TypeEffect { get; set; }
}