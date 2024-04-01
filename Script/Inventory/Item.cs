using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public TileBase tile;
    public ItemType itemType;
    public ActionType actionType;

    [Header("UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
    public GameObject gameObject;
}

public enum ItemType
{
    BuilingBlock,
    PlantProduct,
    PlantSeed,
    Tool
}

public enum ActionType
{
    Water,
    Chop,
    Cultivate,
    Plant,
    Harvest,
    Mine,
    Attack
}
