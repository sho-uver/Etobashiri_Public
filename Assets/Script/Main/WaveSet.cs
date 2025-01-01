using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSet : MonoBehaviour
{
    public Wave waveL;
    public Wave waveR;

    // Start is called before the first frame update
    void Start()
    {
        switch(Random.Range(0,2))
        {
            case 0:
                SetMoveFlgTrueL();
                break;

            case 1:
                SetMoveFlgTrueR();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMoveFlgTrueL()
    {
        waveL.SetMoveFlgTrue();
    }

    public void SetMoveFlgTrueR()
    {
        waveR.SetMoveFlgTrue();
    }
}
