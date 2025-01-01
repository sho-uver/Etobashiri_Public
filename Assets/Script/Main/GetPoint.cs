using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    public float lifeTime;
    public float lifeTimeLimit;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
        lifeTimeLimit = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime > lifeTimeLimit)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetLifeTimeLimit(float num)
    {
        lifeTimeLimit = num;
    }
}
