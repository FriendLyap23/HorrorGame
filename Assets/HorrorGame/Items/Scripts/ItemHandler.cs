using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;

    private Transform _currentItemHandTransform;
    private Rigidbody _currentItemHandRigidbody;

    [SerializeField] private float _rayDistance;
    [SerializeField] public Transform _itemHoldingPoint; 
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
            RayCast();

        if (Input.GetButton("Fire2"))
            DropItem();
    }

    private void PickUpItem()
    {
        Transform itemTransform = _hit.transform;
        ItemDataHolder itemDataHolder = itemTransform.GetComponent<ItemDataHolder>();

        _currentItemHandTransform = itemTransform.transform;
        _currentItemHandRigidbody = itemTransform.GetComponent<Rigidbody>();

        _currentItemHandRigidbody.isKinematic = true;

        itemTransform.position = _itemHoldingPoint.position + _itemHoldingPoint.
            TransformDirection(itemDataHolder.ItemData.PositionItem);
        itemTransform.rotation = _itemHoldingPoint.rotation * Quaternion.Euler(itemDataHolder.ItemData.RotationItem);

        itemTransform.SetParent(_itemHoldingPoint.transform);
    }

    private void DropItem()
    {
        _currentItemHandRigidbody.isKinematic = false;
        _currentItemHandTransform.SetParent(null);
    }

    private void RayCast() 
    {
        Camera camera = Camera.main;
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        _ray = camera.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(_ray, out _hit, _rayDistance) && (_layerMask & (1 << _hit.collider.gameObject.layer)) != 0)
            PickUpItem();
        else
            Debug.Log("No object hit");
    }
}
