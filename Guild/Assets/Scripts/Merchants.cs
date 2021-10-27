using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TypeMerchants
{
    Altruist, // альтруист
    Faker,  // кидала
    SlyOne, //хитрец
    Unpredictable,  // непредсказуемый	
    Vindictive, // злопамятный
    Quirky // ушлый
}

public abstract class Merchants 
{
    public int Money { get; set; }
    public TypeMerchants Type { get; set; }
    public bool TheCrook { get; set; }

    public abstract bool BehaviorVerification(bool opponentBehavior);

    public abstract Merchants Clone();

    public abstract void StatusUpdate();

    public abstract int SearchNumberOfInstances();

    /*public Merchants(int _money, TypeMerchants _type, bool _theCrook)
    {
        Money = _money;
        Type = _type;
        TheCrook = _theCrook;
    }*/
}
