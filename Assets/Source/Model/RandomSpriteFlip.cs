using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpriteFlip : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _chanceFlip;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        Flip();
    }

    private void Flip()
    {
        int chance = Random.Range(0, 100);
        if (chance >= _chanceFlip)
            _sprite.flipX = true;
    }
}