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

    public string Name { get => name; }

    public string Description { get => name; }

    public PokemonType Type { get => type; }

    public int Power { get => power; }

    public int Accuracy { get => accuracy; }

    public int PP { get => pp; }
}
