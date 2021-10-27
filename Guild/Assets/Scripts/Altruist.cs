using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altruist : Merchants
{
    // Всегда сотрудничает.
    public override  bool BehaviorVerification(bool OpponentBehavior)
    {
        TheCrook = false;
        return TheCrook;
    }

    public override Merchants Clone()
    {
        return new Altruist();
    }

    public override int SearchNumberOfInstances()
    {
        return 0;
    }

    public override void StatusUpdate()
    {
        TheCrook = false;
    }
}
