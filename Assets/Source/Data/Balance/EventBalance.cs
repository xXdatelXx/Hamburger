using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/Event", fileName = "EventBalance")]
public class EventBalance : ScriptableObject
{
    [SerializeField, Range(0, 10)] private int _hamburgerToEvent = 5;
    public int HamburgerToEvent => _hamburgerToEvent;

    [SerializeField, Range(0, 10)] private int _randomPairinLevel1;
    public int RandomPairinLevel1 => _randomPairinLevel1;
    [SerializeField, Range(0, 10)] private int _randomPairinLevel2;
    public int RandomPairinLevel2 => _randomPairinLevel2;
    [SerializeField, Range(0, 10)] private int _randomPairinLevel3;
    public int RandomPairinLevel3 => _randomPairinLevel3;
    [SerializeField, Range(0, 10)] private int _randomPairinLevel4;
    public int RandomPairinLevel4 => _randomPairinLevel4;
    [SerializeField, Range(0, 10)] private int _randomPairinLevelMax;
    public int RandomPairinLevelMax => _randomPairinLevelMax;

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _randomPairinLevel1, 0);
        validate.ValidateValue(ref _randomPairinLevel2, _randomPairinLevel1);
        validate.ValidateValue(ref _randomPairinLevel3, _randomPairinLevel2);
        validate.ValidateValue(ref _randomPairinLevel4, _randomPairinLevel3);
        validate.ValidateValue(ref _randomPairinLevelMax, _randomPairinLevel4);
    }
}
