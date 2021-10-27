using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject prefabString;
    [SerializeField] private Transform parentGO;
    [SerializeField] private Text buttonText;
    [SerializeField] private GameObject leaderPanel;
    private int numberAge=0;

    public void FillInTheTable()
    {
        for(int i = 0; i < parentGO.childCount; i++)
        {
            Destroy(parentGO.GetChild(i).gameObject);
        }

        var array = GetComponent<Manager>().MerchantsArray;
        var arrayInt = GetComponent<Manager>().NumberOfInstances;

        for (int i = 1; i<array.Length+1; i++)
        {
            GameObject go = Instantiate(prefabString, parentGO);
            go.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            go.transform.GetChild(1).GetComponent<Text>().text = array[i-1].Type.ToString();
            go.transform.GetChild(2).GetComponent<Text>().text = array[i-1].Money.ToString();
        }
        numberAge++;
        int maxValue=0;
        if (numberAge > 10)
        {
            // определение наиболее выгодной стратегии
            foreach (int j in arrayInt)
            {
                if (j > maxValue)
                {
                    maxValue = j;
                }
            }
            leaderPanel.GetComponent<Text>().text = $"{array[maxValue].Type}" + " - наиболее выгодная стратегия";
            leaderPanel.SetActive(true);
        }
        buttonText.text = $"{numberAge}" + " year";
    }


}
