using UnityEngine;

public class CloseBtn : MonoBehaviour
{
    public GameObject parentObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        parentObj.SetActive(false);
    }
}
