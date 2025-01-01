using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberationPower : MonoBehaviour
{
    public GameObject liberationPower;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeLiberationPower()
    {
        Vector2 liberationPowerPos = new Vector2(Random.Range(-2.1f,2.1f), player.transform.position.y + 19.2f);
        Instantiate(liberationPower, liberationPowerPos , transform.rotation);
    }
}
