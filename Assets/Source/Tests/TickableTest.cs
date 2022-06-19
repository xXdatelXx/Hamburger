using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class TickableTest
{
    [UnityTest]
    public IEnumerator TickableTicking()
    {
        var controller = new GameObject().AddComponent<TickableController>();
        var stopWatch = new Stopwatch();
        controller.Add(stopWatch);
        stopWatch.Play();

        yield return new WaitForFixedUpdate();

        Assert.AreNotEqual(stopWatch.Time, 0);
    }
}
