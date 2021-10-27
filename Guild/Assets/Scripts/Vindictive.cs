using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vindictive : Merchants
{
    // Начинает с сотрудничества и продолжает сотрудничать, пока против него не сжульничают. После этого сам начинает постоянно жульничать.
    public override bool BehaviorVerification(bool opponentBehavior)
    {
        if (opponentBehavior==true && TheCrook==false)
        {
            TheCrook = opponentBehavior;
        }
        return TheCrook;
    }

    public override Merchants Clone()
    {
        return new Vindictive();
    }

    public override int SearchNumberOfInstances()
    {
        return 4;
    }

    public override void StatusUpdate()
    {
        TheCrook = false;
    }
}
