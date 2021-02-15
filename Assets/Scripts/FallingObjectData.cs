using UnityEngine;

public enum Type
{
    Friendly,
    Enemy
}

[CreateAssetMenu(fileName = "New FallingObject", menuName = "FallingObjects")]
public class FallingObjectData : ScriptableObject
{
    public Color color;
    public float speed;
    public Vector2 scale;
    public Type type;
}
