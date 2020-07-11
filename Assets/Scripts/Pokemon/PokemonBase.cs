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
    Dragon,
    Dark,
    Steel
}

public class TypeChart
{
    static float one = 1f;
    static float two = 2f;
    static float haf = 0.5f;
    static float zro = 0f;

    static float[][] chart =
    {
        //            NOR  FIR  WAT  ELE  GRA  ICE  FIG  POI  GRO  FLY  PSY  BUG  ROC  GHO  DRA  DRK  STL
        new float[] { one, one, one, one, one, one, one, one, one, one, one, one, haf, zro, one, one, haf },
        new float[] { one, haf, haf, one, two, two, one, one, one, one, one, two, haf, one, haf, one, two },
        new float[] { one, two, haf, two, haf, one, one, one, two, one, one, one, two, one, haf, one, one },
        new float[] { one, one, two, haf, haf, two, one, one, zro, two, one, one, one, one, haf, one, one },
        new float[] { one, haf, two, two, haf, one, one, haf, two, haf, one, haf, two, one, haf, one, haf },
        new float[] { one, haf, haf, one, two, haf, one, one, two, two, one, one, one, one, two, one, haf },
        new float[] { two, one, one, one, one, two, one, haf, one, haf, haf, haf, two, zro, one, two, two },
        new float[] { one, one, one, one, two, one, one, haf, haf, one, one, one, haf, haf, one, one, zro },
        new float[] { one, two, one, two, haf, one, one, two, one, zro, one, haf, two, one, one, one, two },
        new float[] { one, one, one, haf, two, one, two, one, one, one, one, two, haf, one, one, one, haf },
        new float[] { one, one, one, one, one, one, two, two, one, one, haf, one, one, one, one, zro, haf },
        new float[] { one, haf, one, one, two, one, haf, haf, one, haf, two, one, one, haf, one, two, haf },
        new float[] { one, two, one, one, one, two, haf, one, haf, two, one, two, one, one, one, one, haf },
        new float[] { zro, one, one, one, one, one, one, one, one, one, two, one, one, two, one, haf, haf },
        new float[] { one, one, one, one, one, one, one, one, one, one, one, one, one, one, two, one, haf },
        new float[] { one, one, one, one, one, one, haf, one, one, one, two, one, one, two, one, haf, haf },
        new float[] { one, haf, haf, haf, one, two, one, one, one, one, one, one, two, one, one, one, haf }
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
            return 1f;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }

}