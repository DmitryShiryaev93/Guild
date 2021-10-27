using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpredictable : Merchants
{
    // Поступает случайным образом.
    public override bool BehaviorVerification(bool opponentBehavior)
    {
        int rnd = Random.Range(0, 1);

        if (rnd == 0)
        {
            TheCrook = false;
        }
        else
        {
            TheCrook = true;
        }
        return TheCrook;
    }

    public override Merchants Clone()
    {
        return new Unpredictable();
    }

    public override int SearchNumberOfInstances()
    {
        return 3;
    }

    public override void StatusUpdate()
    {
        
    }
}