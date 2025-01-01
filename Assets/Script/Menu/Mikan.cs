using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mikan : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Vector3 startPos;
    public GameObject mikanPrefab;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {

    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint (pointerEventData.position);
		TargetPos.z = 0;
		transform.position = TargetPos;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        Instantiate(mikanPrefab,transform.position,transform.rotation);
        transform.position = startPos;
    }


}
