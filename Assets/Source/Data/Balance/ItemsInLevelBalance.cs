using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/ItemsInLevel", fileName = "ItemsInLevelBalance")]
public class ItemsInLevelBalance : ScriptableObject
{
    [Header("Level 1")]
    [SerializeField, Range(0, 30)] private int _minItemsInFirstLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxItemsInFirstLevel = 0;
    public (int, int) ItemsInFirstLevel => (_minItemsInFirstLevel, _maxItemsInFirstLevel);

    [Header("Level 2")]
    [SerializeField, Range(0, 30)] private int _minItemsInSecondLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxItemsInSecondLevel = 0;
    public (int, int) ItemsInSecondLevel => (_minItemsInSecondLevel, _maxItemsInSecondLevel);

    [Header("Level 3")]
    [SerializeField, Range(0, 30)] private int _minItemsInThirdtLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxItemsInThirdtLevel = 0;
    public (int, int) ItemsInThirdLevel => (_minItemsInThirdtLevel, _maxItemsInThirdtLevel);

    [Header("Level 4")]
    [SerializeField, Range(0, 30)] private int _minItemsInFourthLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxItemsInFourthLevel = 0;
    public (int, int) ItemsInFourthtLevel => (_minItemsInFourthLevel, _maxItemsInFourthLevel);

    [Header("Max level")]
    [SerializeField, Range(0, 30)] private int _minItemsInMaxLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxItemsInMaxLevel = 0;
    public (int, int) ItemsInMaxLevel => (_minItemsInMaxLevel, _maxItemsInMaxLevel);

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _minItemsInFirstLevel, 0);
        validate.ValidateValue(ref _maxItemsInFirstLevel, _minItemsInFirstLevel);

        validate.ValidateValue(ref _minItemsInSecondLevel, _maxItemsInFirstLevel);
        validate.ValidateValue(ref _maxItemsInSecondLevel, _minItemsInSecondLevel);

        validate.ValidateValue(ref _minItemsInThirdtLevel, _maxItemsInSecondLevel);
        validate.ValidateValue(ref _maxItemsInThirdtLevel, _minItemsInThirdtLevel);

        validate.ValidateValue(ref _minItemsInFourthLevel, _maxItemsInThirdtLevel);
        validate.ValidateValue(ref _maxItemsInFourthLevel, _minItemsInFourthLevel);

        validate.ValidateValue(ref _minItemsInMaxLevel, _maxItemsInFourthLevel);
        validate.ValidateValue(ref _maxItemsInMaxLevel, _minItemsInMaxLevel);
    }
}
