using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearPop : MonoBehaviour
{
    public GameObject year1,year2,year3,year4,year5,year6,year7,year8,year9,year10,year11,year12,year13;
    public GameObject yearLevel;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetYear(int year){
        year++;
        switch(year){
            case 1:
                year1.SetActive(true);
                break;

            case 2:
                year2.SetActive(true);
                break;

            case 3:
                year3.SetActive(true);
                break;

            case 4:
                year4.SetActive(true);
                break;

            case 5:
                year5.SetActive(true);
                break;

            case 6:
                year6.SetActive(true);
                break;

            case 7:
                year7.SetActive(true);
                break;

            case 8:
                year8.SetActive(true);
                break;

            case 9:
                year9.SetActive(true);
                break;

            case 10:
                year10.SetActive(true);
                break;

            case 11:
                year11.SetActive(true);
                break;

            case 12:
                year12.SetActive(true);
                break;

            case 13:
                year13.SetActive(true);
                yearLevel.SetActive(false);
                break;
        }

    }
    public void SetGoal(){
        goal.SetActive(true);
        yearLevel.SetActive(false);
    }
}
