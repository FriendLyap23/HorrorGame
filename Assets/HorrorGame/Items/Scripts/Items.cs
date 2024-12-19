using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/ItemData")]
public class Items : ScriptableObject
{
    [field: SerializeField] public Vector3 RotationItem { get; private set; }
    [field: SerializeField] public Vector3 PositionItem { get; private set; }
}
