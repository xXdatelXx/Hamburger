using UnityEngine;

public abstract class ItemFactory : MonoBehaviourFactory<Item>
{
    private Vector2 _itemUpPosition;

    protected override void SetPosition(Item item)
    {
        float positionX = item.transform.position.x;

        item.transform.position = _itemUpPosition - item.DownLocalPosition;
        item.transform.position = new Vector2(positionX, item.transform.position.y);

        _itemUpPosition = item.UpPosition;
    }

    public void ResetSpawnPosition()
    {
        _itemUpPosition = Vector2.zero;
    }
}
