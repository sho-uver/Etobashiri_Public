using System;
using UnityEngine;

public class LoginBonus : MonoBehaviour
{
    public static LoginBonus instance;
    private DateTime lastLoginDate;
    public int present;
    public MenuSystem menuSystem;
    public Sprite enImage;
    public SnapbarManager snapbarManager;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckLogin()
    {
        DateTime today = DateTime.Today;
        string lastLogin = PlayerPrefs.GetString("LastLoginDate", string.Empty);
        int counter = PlayerPrefs.GetInt("LoginCounter", 0);

        if (!string.IsNullOrEmpty(lastLogin))
        {
            lastLoginDate = DateTime.Parse(lastLogin);
            if (lastLoginDate == today.AddDays(-1))
            {
                counter++;
            }
            else if (lastLoginDate < today.AddDays(-1))
            {
                counter = 1;  // Reset counter if the login was not consecutive
            }
            else if(lastLoginDate == today)
            {
                // counter++;
                return;
                // Debug.Log("TODAY");
            }
        }
        else
        {
            counter = 1;  // Initialize counter for the first login
        }

        PlayerPrefs.SetInt("LoginCounter", counter);
        PlayerPrefs.SetString("LastLoginDate", today.ToString());
        // PlayerPrefs.Save();

        RewardPlayer(counter);
    }

    private void RewardPlayer(int counter)
    {
        present = 10000;
        for (int i = 1; i < counter; i++)
        {
            // 報酬のロジックをここに追加
            present = present * 2;
            // Debug.Log("報酬を付与: " + (i + 1));
        }
        Debug.Log(present);
        string message = "ログインボーナスとして\n" + present + "縁獲得\n明日は今日の倍もらえるよ！";
        snapbarManager.ShowSnapbar(message, enImage, 3);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + present);
        menuSystem.ChangeStageInfo();
        
    }
}
