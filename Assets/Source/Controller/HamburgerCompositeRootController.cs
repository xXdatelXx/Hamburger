using System;
using UnityEngine;
using Zenject;

public class HamburgerCompositeRootController : MonoBehaviour
{
   [Inject] private HamburgerCompositeRoot _compositeRoot;
   [Inject] private EventBalance _balance;
   [Inject] private GameLevel _level;
   
   public void RandomInit()
   {
       int randomPair = _level.GetGameLevel() switch
       {
           Level.First => _balance.RandomPairinLevel1,
           Level.Second => _balance.RandomPairinLevel2,
           Level.Third => _balance.RandomPairinLevel3,
           Level.Fourth => _balance.RandomPairinLevel4,
           Level.Max => _balance.RandomPairinLevelMax,
           _ => throw new InvalidOperationException()
       };
       
       _compositeRoot.RandomizeItems(randomPair);
   }
}
