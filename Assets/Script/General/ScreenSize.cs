using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public Vector2 baseSize;
    public Camera camera;
    public Rect safeArea;
    public float scopeSafeArea;
    public float scopeBase;
    // Start is called before the first frame update
    void Start()
    {
        baseSize = new Vector2(1179,2556);
        camera = gameObject.GetComponent<Camera>();

        safeArea = Screen.safeArea;
        scopeSafeArea = Screen.height / safeArea.size.y;
        scopeBase = baseSize.y / safeArea.size.y;
        camera.orthographicSize =  8 * scopeSafeArea * scopeBase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
