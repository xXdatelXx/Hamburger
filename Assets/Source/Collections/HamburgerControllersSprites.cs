using System.Collections.Generic;
using UnityEngine;

public class HamburgerControllersSprites : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    public IReadOnlyList<Sprite> Sprites => _sprites;
    public int Count => _sprites.Count;
}
