using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quirky : Merchants
{
    //Всегда начинает с последовательности ходов: сотрудничество, жульничество, сотрудничество, сотрудничество. 
    //Далее, если к пятому ходу его хоть раз обманули, то играет как кидала, если нет, то как хитрец.


    int transactionNumber;
    bool aSlyManOrAScammer;

    public override bool BehaviorVerification(bool opponentBehavior)
    {
        if (opponentBehavior==true) // обманули ли хоть один раз?
        {
            aSlyManOrAScammer = true;
        }

        if (transactionNumber == 1)
        {
            TheCrook = true;
        }
        else if(transactionNumber==0|| transactionNumber == 2|| transactionNumber == 3)
        {
            TheCrook = false;
        }


        if(transactionNumber > 3)
        {
            if (aSlyManOrAScammer==true)
            {
                // кидала
                TheCrook = true;
            }
            else if (aSlyManOrAScammer==false)
            {
                // хитрец
                if (transactionNumber == 4)
                {
                    TheCrook = false;
                }
                else
                {
                    TheCrook = opponentBehavior;
                }
            }
        }

        transactionNumber++;
        return TheCrook;
    }

    public override Merchants Clone()
    {
        return new Quirky();
    }

    public override int SearchNumberOfInstances()
    {
        return 5;
    }

    public override void StatusUpdate()
    {
        aSlyManOrAScammer = false;
        transactionNumber = 0;
        TheCrook = false;  
    }
}
