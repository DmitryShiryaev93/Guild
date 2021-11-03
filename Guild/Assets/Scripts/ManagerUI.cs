using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject prefabString;
    [SerializeField] private Transform parentGO;
    [SerializeField] private Text buttonText;
    [SerializeField] private Text leaderPanel;
    private int numberAge = 0;

    Merchants[] arrayLink;
    int[] arrayIntLink;

    private void Awake()
    {
        arrayLink = GetComponent<Manager>().MerchantsArray;
        arrayIntLink = GetComponent<Manager>().NumberOfInstances;
    }

    public void FillInTheTable()
    {
        for(int i = 0; i < parentGO.childCount; i++)
        {
            Destroy(parentGO.GetChild(i).gameObject);
        }

        for (int i = 1; i< arrayLink.Length+1; i++)
        {
            GameObject go = Instantiate(prefabString, parentGO);

            foreach (Transform child in go.transform)
            {
                switch (child.tag)
                {
                    case "TagNumber":
                        child.GetComponent<Text>().text = i.ToString();
                        break;
                    case "TagName":
                        child.GetComponent<Text>().text = arrayLink[i - 1].Type.ToString();
                        break;
                    case "TagMoney":
                        child.GetComponent<Text>().text = arrayLink[i - 1].Money.ToString();
                        break;
                }
            }
        }

        numberAge++;
        int maxValue=0;

        if (numberAge > 10)
        {
            // определение наиболее выгодной стратегии
            foreach (int j in arrayIntLink)
            {
                if (j > maxValue)
                {
                    maxValue = j;
                }
            }
            leaderPanel.text = $"{arrayLink[maxValue].Type}" + " - наиболее выгодная стратегия";
            leaderPanel.gameObject.SetActive(true);
        }
        buttonText.text = $"{numberAge}" + " year";
    }
}
