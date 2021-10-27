using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faker : Merchants
{
    // Всегда жульничает.
    public override bool BehaviorVerification(bool OpponentBehavior)
    {
        TheCrook = true;
        return TheCrook;
    }

    public override Merchants Clone()
    {
        return new Faker();
    }

    public override int SearchNumberOfInstances()
    {
        return 1;
    }

    public override void StatusUpdate()
    {
        TheCrook = true;
    }
}
