using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/Level", fileName = "LevelBalance")]
public class LevelBalance : ScriptableObject
{
    [SerializeField, Range(0, 30)] private int _itemsInFirstLevel = 0;
    public int ItemsInFirstLevel => _itemsInFirstLevel;

    [SerializeField, Range(0, 30)] private int _itemsInSecondLevel = 0;
    public int ItemsInSecondLevel => _itemsInSecondLevel;

    [SerializeField, Range(0, 30)] private int _itemsInThirdtLevel = 0;
    public int ItemsInThirdLevel => _itemsInThirdtLevel;

    [SerializeField, Range(0, 30)] private int _itemsInFourthLevel = 0;
    public int ItemsInFourthtLevel => _itemsInFourthLevel;

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _itemsInFirstLevel, 0);
        validate.ValidateValue(ref _itemsInSecondLevel, _itemsInFirstLevel);
        validate.ValidateValue(ref _itemsInThirdtLevel, _itemsInSecondLevel);
        validate.ValidateValue(ref _itemsInFourthLevel, _itemsInThirdtLevel);
    }
}
