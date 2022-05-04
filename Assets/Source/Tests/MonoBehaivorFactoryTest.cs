using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MonoBehaivorFactoryTest
{
    [Test]
    public void DestroyAll_DestroingAll()
    {
        var factory = new TestFactory();

        factory.Create(new GameObject().AddComponent<TestItem>());
        factory.Create(new GameObject().AddComponent<TestItem>());
        factory.DestroyAll();
        List<TestItem> items = GameObject.FindObjectsOfType<TestItem>().ToList();

        bool destroyAllDestroingAll = factory.EntitiesCount == 0;

        Assert.AreEqual(true, destroyAllDestroingAll);
    }

    [Test]
    public void Add_AddToScene()
    {
        var factory = new TestFactory();

        factory.Create(new GameObject().AddComponent<TestItem>());
        List<TestItem> items = GameObject.FindObjectsOfType<TestItem>().ToList();

        bool createAddToScene = factory.EntitiesCount == 1;

        Assert.AreEqual(true, createAddToScene);
    }

    class TestFactory : MonoBehaviourFactory<TestItem>
    {
        protected override void SetPosition(TestItem entity)
        {
        }
    }

    class TestItem : MonoBehaviour { }
}
