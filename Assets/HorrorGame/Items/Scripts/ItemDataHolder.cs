using UnityEngine;

public class ItemDataHolder : MonoBehaviour
{
    [SerializeField] private Items _itemDara;

    public Items ItemData => _itemDara;
}
