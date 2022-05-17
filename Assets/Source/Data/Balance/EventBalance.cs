using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/Event", fileName = "EventBalance")]
public class EventBalance : ScriptableObject
{
    [SerializeField, Range(0, 10)] private int _hamburgersToEvent = 5;
    public int HamburgersToEvent => _hamburgersToEvent;

    [SerializeField, Range(0, 10)] private int _randomPairInLevel1;
    public int RandomPairInLevel1 => _randomPairInLevel1;
    [SerializeField, Range(0, 10)] private int _randomPairInLevel2;
    public int RandomPairInLevel2 => _randomPairInLevel2;
    [SerializeField, Range(0, 10)] private int _randomPairInLevel3;
    public int RandomPairInLevel3 => _randomPairInLevel3;
    [SerializeField, Range(0, 10)] private int _randomPairInLevel4;
    public int RandomPairInLevel4 => _randomPairInLevel4;
    [SerializeField, Range(0, 10)] private int _randomPairInLevelMax;
    public int RandomPairInLevelMax => _randomPairInLevelMax;

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _randomPairInLevel1, 0);
        validate.ValidateValue(ref _randomPairInLevel2, _randomPairInLevel1);
        validate.ValidateValue(ref _randomPairInLevel3, _randomPairInLevel2);
        validate.ValidateValue(ref _randomPairInLevel4, _randomPairInLevel3);
        validate.ValidateValue(ref _randomPairInLevelMax, _randomPairInLevel4);
    }
}
