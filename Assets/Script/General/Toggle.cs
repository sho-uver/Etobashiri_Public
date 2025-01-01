using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Toggle : MonoBehaviour
{
    public GameObject DebugWindow;

    // Start と Updateは省略

    public void OnValueChanged(bool val)
    {
        // デバッグウインドウの表示切り替え
        // ToggleがONの時表示（Active）
        // ToggleがOFFの時非表示（Deactive）
        DebugWindow.SetActive(val);
    }
}