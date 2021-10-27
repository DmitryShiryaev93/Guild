using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlyOne : Merchants
{
    // Начинает с сотрудничества, потом повторяет ход оппонента.
    int numberStep=0;
    public override bool BehaviorVerification(bool opponentBehavior)
    {
        if (numberStep > 0)
        {
            TheCrook = opponentBehavior;
        }
        numberStep++;
        return TheCrook;
    }

    public override Merchants Clone()
    {
        return new SlyOne();
    }

    public override int SearchNumberOfInstances()
    {
        return 2;
    }

    public override void StatusUpdate()
    {
        numberStep = 0;
        TheCrook = false;
    }
}
