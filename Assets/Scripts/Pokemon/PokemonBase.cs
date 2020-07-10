using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create New Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField]
    private string name;

    [TextArea]
    [SerializeField]
    private string description;

    [SerializeField]
    private Sprite frontSprite;

    [SerializeField]
    private Sprite backSprite;

    [SerializeField]
    private PokemonType type1;

    [SerializeField]
    private PokemonType type2;


    // base stats
    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int attack;

    [SerializeField]
    private int defense;

    [SerializeField]
    private int spAttack;

    [SerializeField]
    private int spDefense;

    [SerializeField]
    private int speed;

    [SerializeField]
    List<LearnableMove> learnableMoves;

    public string Name { get => name; }

    public string Description { get => name; }

    public Sprite FrontSprite { get => frontSprite; }

    public Sprite BackSprite { get => backSprite; }

    public PokemonType Type1 { get => type1; }

    public PokemonType Type2 { get => type2; }

    public int MaxHp { get => maxHp; }

    public int Attack { get => attack; }

    public int Defense { get => defense; }

    public int SpAttack { get => spAttack; }

    public int SpDefense { get => spDefense; }

    public int Speed { get => speed; }

    public List<LearnableMove> LearnableMoves { get => learnableMoves; }

}

[System.Serializable]
public class LearnableMove
{
    [SerializeField]
    private MoveBase moveBase;

    [SerializeField]
    private int level;

    public MoveBase MoveBase { get => moveBase; }

    public int Level { get => level; }
}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}