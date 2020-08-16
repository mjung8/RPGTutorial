using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField]
    private string name;

    [TextArea]
    [SerializeField]
    private string description;

    [SerializeField]
    private PokemonType type;

    [SerializeField]
    private int power;

    [SerializeField]
    private int accuracy;

    [SerializeField]
    private int pp;

    [SerializeField]
    private MoveCategory category;

    [SerializeField]
    private MoveEffects effects;

    [SerializeField]
    private MoveTarget target;

    public string Name { get => name; }

    public string Description { get => name; }

    public PokemonType Type { get => type; }

    public int Power { get => power; }

    public int Accuracy { get => accuracy; }

    public int PP { get => pp; }

    public MoveCategory Category { get => category; }

    public MoveEffects Effects { get => effects; }

    public MoveTarget Target { get => target; }
}

[System.Serializable]
public class MoveEffects
{
    [SerializeField]
    private List<StatBoost> boosts;

    public List<StatBoost> Boosts { get => boosts; }
}

[System.Serializable]
public class StatBoost
{
    public Stat stat;
    public int boost;
}

public enum MoveCategory
{
    Physical, Special, Status
}

public enum MoveTarget
{
    Foe, Self
}