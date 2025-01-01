using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mileage : MonoBehaviour
{
    public float mileage;
    public Text mileageText;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        mileage = PlayerPrefs.GetInt("Mileage", 0);
        level = PlayerPrefs.GetInt("Level", 999);
        // mileageText.text = "今まで走った距離" + mileage.ToString() + "km";
        mileageText.text = "階級:" + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
