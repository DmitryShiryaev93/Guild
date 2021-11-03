using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Merchants[] MerchantsArray { get; } = new Merchants[60];
    public int[] NumberOfInstances { get; set; } = { 10, 10, 10, 10, 10, 10 };

    ManagerUI mangerUI;

    private void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            if (i >= 0 && i <= 9)
            {
                MerchantsArray[i] = new Altruist();
                MerchantsArray[i].Type = TypeMerchants.Altruist;
            }
            else if (i >= 10 && i <= 19)
            {
                MerchantsArray[i] = new Faker();
                MerchantsArray[i].Type = TypeMerchants.Faker;
            }
            else if(i >= 20 && i <= 29)
            {
                MerchantsArray[i] = new SlyOne();
                MerchantsArray[i].Type = TypeMerchants.SlyOne;
            }
            else if(i >= 30 && i <= 39)
            {
                MerchantsArray[i] = new Unpredictable();
                MerchantsArray[i].Type = TypeMerchants.Unpredictable;
            }
            else if(i >= 40 && i <= 49)
            {
                MerchantsArray[i] = new Vindictive();
                MerchantsArray[i].Type = TypeMerchants.Vindictive;
            }
            else if(i >= 50 && i <= 59)
            {
                MerchantsArray[i] = new Quirky();
                MerchantsArray[i].Type = TypeMerchants.Quirky;
            }
        }

        for (int i = MerchantsArray.Length - 1; i >= 0; i--) // перемешать
        {
            int j = Random.Range(0, i + 1);
            var temp = MerchantsArray[j];
            MerchantsArray[j] = MerchantsArray[i];
            MerchantsArray[i] = temp;
        }

        mangerUI = GetComponent<ManagerUI>();
        mangerUI.FillInTheTable();
    }

    int movingIndex = 0;

    public void NextYear()
    {
        for (int k = 0; k < MerchantsArray.Length; k++)
        {
            MerchantsArray[k].Money = 0;
        }
        Auction();
    }

    void Auction()
    {
        for(int k=0; k <= 59; k++)
        {
            bool merchantBehavior = MerchantsArray[movingIndex].TheCrook;

            for (int i = movingIndex + 1; i < MerchantsArray.Length; i++)
            {
                bool opponentBehavior = MerchantsArray[i].TheCrook;

                int rnd = Random.Range(5, 10); // от 5 до 10 сделок

                for (int j = 0; j < rnd; j++)
                {
                    merchantBehavior = CheckingForErrors(merchantBehavior); // 5 - ти процентная вероятность совершить ошибку
                    opponentBehavior = CheckingForErrors(opponentBehavior);

                    if (MerchantsArray[movingIndex].BehaviorVerification(opponentBehavior) == false && MerchantsArray[i].BehaviorVerification(merchantBehavior) == false)
                    {
                        MerchantsArray[movingIndex].Money += 4;
                        MerchantsArray[i].Money += 4;
                    }
                    else if (MerchantsArray[movingIndex].BehaviorVerification(opponentBehavior) == false && MerchantsArray[i].BehaviorVerification(merchantBehavior) == true)
                    {
                        MerchantsArray[movingIndex].Money += 1;
                        MerchantsArray[i].Money += 5;
                    }
                    else if (MerchantsArray[movingIndex].BehaviorVerification(opponentBehavior) == true && MerchantsArray[i].BehaviorVerification(merchantBehavior) == false)
                    {
                        MerchantsArray[movingIndex].Money += 5;
                        MerchantsArray[i].Money += 1;
                    }
                    else if (MerchantsArray[movingIndex].BehaviorVerification(opponentBehavior) == true && MerchantsArray[i].BehaviorVerification(merchantBehavior) == true)
                    {
                        MerchantsArray[movingIndex].Money += 2;
                        MerchantsArray[i].Money += 2;
                    }
                }
                MerchantsArray[movingIndex].StatusUpdate();
                MerchantsArray[i].StatusUpdate();
            }
            movingIndex++;
        }

        movingIndex = 0;
        Sort(); // пузырьком
        UpdateArrayOfMerchants(); // выгнать и пригласить
        mangerUI.FillInTheTable();
    } 

    bool CheckingForErrors(bool error)
    {
        int rnd = Random.Range(0, 100);
        if (rnd <= 5)
        {
            error = !error;
        }
        return error;
    }

    void Swop(int posA, int posB)
    {
        if (posA < MerchantsArray.Length && posB < MerchantsArray.Length)
        {
            var temp = MerchantsArray[posA];
            MerchantsArray[posA] = MerchantsArray[posB];
            MerchantsArray[posB] = temp;
        }
    }

    void Sort()
    {
        var count = MerchantsArray.Length;

        for(int j = 0; j < count; j++)
        {
            for (int i = 59; i >0; i--)
            {
                if (MerchantsArray[i].Money.CompareTo(MerchantsArray[i - 1].Money) == 1)
                {
                    Swop(i, i - 1);
                }
            }
            count--;
        }
    }

    
    void UpdateArrayOfMerchants()
    {
        for (int i = 59; i>=48; i--)
        {
            NumberOfInstances[MerchantsArray[i].SearchNumberOfInstances()] -= 1; // выяснить кол-во удалённых типов 

            MerchantsArray[i] = null;
            MerchantsArray[i] = MerchantsArray[59 - i].Clone();
            MerchantsArray[i].Type = MerchantsArray[59 - i].Type;
        }

        for (int i = 59; i >= 48; i--)
        {
            NumberOfInstances[MerchantsArray[59 - i].SearchNumberOfInstances()] += 1; // выяснить кол-во добавленных типов 
        }
    }
}
