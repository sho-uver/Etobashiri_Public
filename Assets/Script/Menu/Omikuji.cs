using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class Omikuji : MonoBehaviour
{
    public TwitterShare ts;
    public LineShare ls;
    public string text;
    public int lack1;
    public int lack2;
    public int lack3;
    public int lack4;
    public int lack5;
    public int lack6;
    public int lack7;
    public int lackTotal;
    public int lackMessage;
    public SnapbarManager snapbarManager;
    public Sprite omikujiImage;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmikujiDraw()
    {
        if(PlayerPrefs.GetInt("超春夏秋冬並木",0) != 1)
        {
            if(PlayerPrefs.GetString("OmikujiDay","") == DateTime.Today.ToString("d"))
            {
                message = "おみくじは一日一回です。";
                snapbarManager.ShowSnapbar(message, omikujiImage, 3);
                return;
            }
        }


        text = "";
        lack1 = UnityEngine.Random.Range(1,6);
        lack2 = UnityEngine.Random.Range(6,11) - 5;
        lack3 = UnityEngine.Random.Range(11,16) - 10;
        lack4 = UnityEngine.Random.Range(16,21) - 15;
        lack5 = UnityEngine.Random.Range(21,26) - 20;
        lack6 = UnityEngine.Random.Range(26,31) - 25;
        lack7 = UnityEngine.Random.Range(31,36) - 30;
        lackTotal = lack1 + lack2 + lack3 + lack4 + lack5 + lack6 + lack7;
        lackMessage = UnityEngine.Random.Range(1,9);
        text += "【えとばしりおみくじ】\n";
        text += "運勢：";
        if(lackTotal >= 7 && lackTotal < 13 )
        {
            text += "大凶\n";
            text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "自分自身がどう在りたいか！";
                    break;
                case 2:
                    text += "失敗から学ぶことも多い！";
                    break;
                case 3:
                    text += "諦めるまでは失敗は失敗ではない！";
                    break;
                case 4:
                    text += "頑張ってるからこそ辛い時もある！";
                    break;
                case 5:
                    text += "最初は誰でも恥をかく！";
                    break;
                case 6:
                    text += "周りに期待されてなくても大丈夫！";
                    break;
                case 7:
                    text += "諦めても楽な日々は始まらないぞ！";
                    break;
                case 8:
                    text += "何をしてもダメな日は仲間を頼ってみよう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",100);
        }
        else if(lackTotal >= 13 && lackTotal < 17)
        {
            text += "凶\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "誰かを思えばもっと頑張れるかも！";
                    break;
                case 2:
                    text += "恥をかかなければ夢は叶わない！";
                    break;
                case 3:
                    text += "普通って場所が遠くに感じる時もある！";
                    break;
                case 4:
                    text += "悪いことをしたらおちゃらけてもすぐに謝った方がいい！";
                    break;
                case 5:
                    text += "誰かと比べて幸せを探すのはやめよう！";
                    break;
                case 6:
                    text += "自分が変わるか周りを変えるか！";
                    break;
                case 7:
                    text += "時には仮面をかぶって自己防衛！";
                    break;
                case 8:
                    text += "すぐに結果が出ると期待してはいけない！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",50);

        }
        else if(lackTotal >= 17 && lackTotal < 20 )
        {
            text += "末吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "負のスパイラルから抜け出すまで頑張ろう！";
                    break;
                case 2:
                    text += "勘違いで調子に乗ることもたまには大事！";
                    break;
                case 3:
                    text += "自分勝手になる日があってもいい！";
                    break;
                case 4:
                    text += "嫌われそうでも自分を一番に考えよう！";
                    break;
                case 5:
                    text += "相手が損する嘘はやめよう！";
                    break;
                case 6:
                    text += "好きなこともやるべきことも全力でやる！";
                    break;
                case 7:
                    text += "一度休んでもまた立ち上がればノーカン！";
                    break;
                case 8:
                    text += "なんでも挑戦する姿勢を貫くと意外とできる！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",10);

        }
        else if(lackTotal >= 20 && lackTotal < 23)
        {
            text += "吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "夢を叶えるためには現実も見よう！";
                    break;
                case 2:
                    text += "物事を分解して考えると閃くかも！";
                    break;
                case 3:
                    text += "自分で輪の中心を作ろう！";
                    break;
                case 4:
                    text += "決めたらやり遂げよう！";
                    break;
                case 5:
                    text += "自分に合うかではなく、やりたいかで行動しよう！";
                    break;
                case 6:
                    text += "他人の気持ちを全ては理解できないことを肝に銘じよう！";
                    break;
                case 7:
                    text += "はじめの一歩は難しいが大きな一歩！";
                    break;
                case 8:
                    text += "知識・行動・気づき・技術・習慣の壁を一つずつ超えていこう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",1);
        }
        else if(lackTotal >= 23 && lackTotal < 25 )
        {
            text += "小吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "昨日の自分に勝とう！";
                    break;
                case 2:
                    text += "敵がいることも活かそう！";
                    break;
                case 3:
                    text += "まずは夢を見つけるところから！";
                    break;
                case 4:
                    text += "どんなに分厚い雲でもその上は晴れている！";
                    break;
                case 5:
                    text += "人と仲良くなりたければ好きなもので共通点を作ろう！";
                    break;
                case 6:
                    text += "明日ではなく、今日やろう！";
                    break;
                case 7:
                    text += "積み上げてきたもの、磨いてきたものをぶつけよう！";
                    break;
                case 8:
                    text += "成功してる未来を想像して頑張ろう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",10);
        }
        else if(lackTotal >= 25 && lackTotal < 29)
        {
            text += "中吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "ちょっとだけでも日々進んでいこう！";
                    break;
                case 2:
                    text += "足すだけでなく削ぎ落とすのも大事！";
                    break;
                case 3:
                    text += "評価されないなら評価されるまで努力を続けよう！";
                    break;
                case 4:
                    text += "諦めた人を努力は裏切る！";
                    break;
                case 5:
                    text += "組織がなくなっても会いたいと思える人間関係を気づこう！";
                    break;
                case 6:
                    text += "流行りは抑えて人と共通の話題を増やそう！";
                    break;
                case 7:
                    text += "やるのとやらされているのは違う！";
                    break;
                case 8:
                    text += "自分の側にいてくれる人を大事にしよう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",50);
        }
        else if(lackTotal >= 29 && lackTotal < 36 )
        {
            text += "大吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "挑戦するなら今日が一番若い日！";
                    break;
                case 2:
                    text += "全部やって確かめよう！";
                    break;
                case 3:
                    text += "行ける所ではなく行きたい所まで行こう！";
                    break;
                case 4:
                    text += "守破離！";
                    break;
                case 5:
                    text += "人からの愛情は倍にして返そう！";
                    break;
                case 6:
                    text += "本気は苦労をいとわない！";
                    break;
                case 7:
                    text += "自分に従って生きよう！";
                    break;
                case 8:
                    text += "情けは人のためならず！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",1000);
        }
        text += "\n";
        text += "\n";
        switch(lack1)
        {
            case 1:
                text += "願望：★\n";
                break;
            case 2:
                text += "願望：★★\n";
                break;
            case 3:
                text += "願望：★★★\n";
                break;
            case 4:
                text += "願望：★★★★\n";
                break;
            case 5:
                text += "願望：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack2)
        {
            case 1:
                text += "恋愛：★\n";
                break;
            case 2:
                text += "恋愛：★★\n";
                break;
            case 3:
                text += "恋愛：★★★\n";
                break;
            case 4:
                text += "恋愛：★★★★\n";
                break;
            case 5:
                text += "恋愛：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack3)
        {
            case 1:
                text += "商売：★\n";
                break;
            case 2:
                text += "商売：★★\n";
                break;
            case 3:
                text += "商売：★★★\n";
                break;
            case 4:
                text += "商売：★★★★\n";
                break;
            case 5:
                text += "商売：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack4)
        {
            case 1:
                text += "学問：★\n";
                break;
            case 2:
                text += "学問：★★\n";
                break;
            case 3:
                text += "学問：★★★\n";
                break;
            case 4:
                text += "学問：★★★★\n";
                break;
            case 5:
                text += "学問：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack5)
        {
            case 1:
                text += "争事：★\n";
                break;
            case 2:
                text += "争事：★★\n";
                break;
            case 3:
                text += "争事：★★★\n";
                break;
            case 4:
                text += "争事：★★★★\n";
                break;
            case 5:
                text += "争事：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack6)
        {
            case 1:
                text += "待人：★\n";
                break;
            case 2:
                text += "待人：★★\n";
                break;
            case 3:
                text += "待人：★★★\n";
                break;
            case 4:
                text += "待人：★★★★\n";
                break;
            case 5:
                text += "待人：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack7)
        {
            case 1:
                text += "失物：★\n";
                break;
            case 2:
                text += "失物：★★\n";
                break;
            case 3:
                text += "失物：★★★\n";
                break;
            case 4:
                text += "失物：★★★★\n";
                break;
            case 5:
                text += "失物：★★★★★\n";
                break;
        }

        text += "\n #えとばしり！\nAndroid\nhttps://play.google.com/store/apps/details?id=com.HishoCompany.Chototsumoshin&pcampaignid=web_share\niOS↓\nhttps://apps.apple.com/jp/app/%E3%81%88%E3%81%A8%E3%81%B0%E3%81%97%E3%82%8A/id6470151998";
        ts.SetTweetText(text);
        ts.SetSSStopFlg();
        ts.Tweet();
        PlayerPrefs.SetString("OmikujiDay",DateTime.Today.ToString("d"));
        message = "おみくじの効果で\n獲得できる縁が" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加！";
        snapbarManager.ShowSnapbar(message, omikujiImage, 60);

    }

    public void OmikujiDrawLine()
    {
        if(PlayerPrefs.GetInt("超春夏秋冬並木",0) != 1)
        {
            if(PlayerPrefs.GetString("OmikujiDay","") == DateTime.Today.ToString("d"))
            {
                message = "おみくじは一日一回です。";
                snapbarManager.ShowSnapbar(message, omikujiImage, 3);
                return;
            }
        }

        text = "";
        lack1 = UnityEngine.Random.Range(1,6);
        lack2 = UnityEngine.Random.Range(6,11) - 5;
        lack3 = UnityEngine.Random.Range(11,16) - 10;
        lack4 = UnityEngine.Random.Range(16,21) - 15;
        lack5 = UnityEngine.Random.Range(21,26) - 20;
        lack6 = UnityEngine.Random.Range(26,31) - 25;
        lack7 = UnityEngine.Random.Range(31,36) - 30;
        lackTotal = lack1 + lack2 + lack3 + lack4 + lack5 + lack6 + lack7;
        lackMessage = UnityEngine.Random.Range(1,9);
        text += "【えとばしりおみくじ】\n";
        text += "運勢：";
        if(lackTotal >= 7 && lackTotal < 13 )
        {
            text += "大凶\n";
            text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "自分自身がどう在りたいか！";
                    break;
                case 2:
                    text += "失敗から学ぶことも多い！";
                    break;
                case 3:
                    text += "諦めるまでは失敗は失敗ではない！";
                    break;
                case 4:
                    text += "頑張ってるからこそ辛い時もある！";
                    break;
                case 5:
                    text += "最初は誰でも恥をかく！";
                    break;
                case 6:
                    text += "周りに期待されてなくても大丈夫！";
                    break;
                case 7:
                    text += "諦めても楽な日々は始まらないぞ！";
                    break;
                case 8:
                    text += "何をしてもダメな日は仲間を頼ってみよう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",100);
            message = "大凶！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";
        }
        else if(lackTotal >= 13 && lackTotal < 17)
        {
            text += "凶\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "誰かを思えばもっと頑張れるかも！";
                    break;
                case 2:
                    text += "恥をかかなければ夢は叶わない！";
                    break;
                case 3:
                    text += "普通って場所が遠くに感じる時もある！";
                    break;
                case 4:
                    text += "悪いことをしたらおちゃらけてもすぐに謝った方がいい！";
                    break;
                case 5:
                    text += "誰かと比べて幸せを探すのはやめよう！";
                    break;
                case 6:
                    text += "自分が変わるか周りを変えるか！";
                    break;
                case 7:
                    text += "時には仮面をかぶって自己防衛！";
                    break;
                case 8:
                    text += "すぐに結果が出ると期待してはいけない！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",50);
            message = "凶！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";

        }
        else if(lackTotal >= 17 && lackTotal < 20 )
        {
            text += "末吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "負のスパイラルから抜け出すまで頑張ろう！";
                    break;
                case 2:
                    text += "勘違いで調子に乗ることもたまには大事！";
                    break;
                case 3:
                    text += "自分勝手になる日があってもいい！";
                    break;
                case 4:
                    text += "嫌われそうでも自分を一番に考えよう！";
                    break;
                case 5:
                    text += "相手が損する嘘はやめよう！";
                    break;
                case 6:
                    text += "好きなこともやるべきことも全力でやる！";
                    break;
                case 7:
                    text += "一度休んでもまた立ち上がればノーカン！";
                    break;
                case 8:
                    text += "なんでも挑戦する姿勢を貫くと意外とできる！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",10);
            message = "末吉！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";

        }
        else if(lackTotal >= 20 && lackTotal < 23)
        {
            text += "吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "夢を叶えるためには現実も見よう！";
                    break;
                case 2:
                    text += "物事を分解して考えると閃くかも！";
                    break;
                case 3:
                    text += "自分で輪の中心を作ろう！";
                    break;
                case 4:
                    text += "決めたらやり遂げよう！";
                    break;
                case 5:
                    text += "自分に合うかではなく、やりたいかで行動しよう！";
                    break;
                case 6:
                    text += "他人の気持ちを全ては理解できないことを肝に銘じよう！";
                    break;
                case 7:
                    text += "はじめの一歩は難しいが大きな一歩！";
                    break;
                case 8:
                    text += "知識・行動・気づき・技術・習慣の壁を一つずつ超えていこう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",1);
            message = "吉！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";
        }
        else if(lackTotal >= 23 && lackTotal < 25 )
        {
            text += "小吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "昨日の自分に勝とう！";
                    break;
                case 2:
                    text += "敵がいることも活かそう！";
                    break;
                case 3:
                    text += "まずは夢を見つけるところから！";
                    break;
                case 4:
                    text += "どんなに分厚い雲でもその上は晴れている！";
                    break;
                case 5:
                    text += "人と仲良くなりたければ好きなもので共通点を作ろう！";
                    break;
                case 6:
                    text += "明日ではなく、今日やろう！";
                    break;
                case 7:
                    text += "積み上げてきたもの、磨いてきたものをぶつけよう！";
                    break;
                case 8:
                    text += "成功してる未来を想像して頑張ろう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",10);
            message = "小吉！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";
        }
        else if(lackTotal >= 25 && lackTotal < 29)
        {
            text += "中吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "ちょっとだけでも日々進んでいこう！";
                    break;
                case 2:
                    text += "足すだけでなく削ぎ落とすのも大事！";
                    break;
                case 3:
                    text += "評価されないなら評価されるまで努力を続けよう！";
                    break;
                case 4:
                    text += "諦めた人を努力は裏切る！";
                    break;
                case 5:
                    text += "組織がなくなっても会いたいと思える人間関係を気づこう！";
                    break;
                case 6:
                    text += "流行りは抑えて人と共通の話題を増やそう！";
                    break;
                case 7:
                    text += "やるのとやらされているのは違う！";
                    break;
                case 8:
                    text += "自分の側にいてくれる人を大事にしよう！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",50);
            message = "中吉！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";
        }
        else if(lackTotal >= 29 && lackTotal < 36 )
        {
            text += "大吉\n";
            // text += "\n";
            text += "今日の一言：";
            switch(lackMessage)
            {
                case 1:
                    text += "挑戦するなら今日が一番若い日！";
                    break;
                case 2:
                    text += "全部やって確かめよう！";
                    break;
                case 3:
                    text += "行ける所ではなく行きたい所まで行こう！";
                    break;
                case 4:
                    text += "守破離！";
                    break;
                case 5:
                    text += "人からの愛情は倍にして返そう！";
                    break;
                case 6:
                    text += "本気は苦労をいとわない！";
                    break;
                case 7:
                    text += "自分に従って生きよう！";
                    break;
                case 8:
                    text += "情けは人のためならず！";
                    break;
            }
            PlayerPrefs.SetInt("Omikuji",1000);
            message = "大吉！\nおみくじの効果で獲得できる縁が\n" + PlayerPrefs.GetInt("Omikuji",0) * 100 + "%増加。";
        }
        text += "\n";
        text += "\n";
        switch(lack1)
        {
            case 1:
                text += "願望：★\n";
                break;
            case 2:
                text += "願望：★★\n";
                break;
            case 3:
                text += "願望：★★★\n";
                break;
            case 4:
                text += "願望：★★★★\n";
                break;
            case 5:
                text += "願望：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack2)
        {
            case 1:
                text += "恋愛：★\n";
                break;
            case 2:
                text += "恋愛：★★\n";
                break;
            case 3:
                text += "恋愛：★★★\n";
                break;
            case 4:
                text += "恋愛：★★★★\n";
                break;
            case 5:
                text += "恋愛：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack3)
        {
            case 1:
                text += "商売：★\n";
                break;
            case 2:
                text += "商売：★★\n";
                break;
            case 3:
                text += "商売：★★★\n";
                break;
            case 4:
                text += "商売：★★★★\n";
                break;
            case 5:
                text += "商売：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack4)
        {
            case 1:
                text += "学問：★\n";
                break;
            case 2:
                text += "学問：★★\n";
                break;
            case 3:
                text += "学問：★★★\n";
                break;
            case 4:
                text += "学問：★★★★\n";
                break;
            case 5:
                text += "学問：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack5)
        {
            case 1:
                text += "争事：★\n";
                break;
            case 2:
                text += "争事：★★\n";
                break;
            case 3:
                text += "争事：★★★\n";
                break;
            case 4:
                text += "争事：★★★★\n";
                break;
            case 5:
                text += "争事：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack6)
        {
            case 1:
                text += "待人：★\n";
                break;
            case 2:
                text += "待人：★★\n";
                break;
            case 3:
                text += "待人：★★★\n";
                break;
            case 4:
                text += "待人：★★★★\n";
                break;
            case 5:
                text += "待人：★★★★★\n";
                break;
        }
        // text += "\n";
        switch(lack7)
        {
            case 1:
                text += "失物：★\n";
                break;
            case 2:
                text += "失物：★★\n";
                break;
            case 3:
                text += "失物：★★★\n";
                break;
            case 4:
                text += "失物：★★★★\n";
                break;
            case 5:
                text += "失物：★★★★★\n";
                break;
        }

        text += "\n #えとばしり！\nAndroid\nhttps://play.google.com/store/apps/details?id=com.HishoCompany.Chototsumoshin&pcampaignid=web_share\niOS↓\nhttps://apps.apple.com/jp/app/%E3%81%88%E3%81%A8%E3%81%B0%E3%81%97%E3%82%8A/id6470151998";
        ls.SetTweetText(text);
        ls.SetSSStopFlg();
        ls.Tweet();
        PlayerPrefs.SetString("OmikujiDay",DateTime.Today.ToString("d"));
        
        snapbarManager.ShowSnapbar(message, omikujiImage, 15);  
    }
}
