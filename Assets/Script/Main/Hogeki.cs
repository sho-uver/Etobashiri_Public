using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hogeki : MonoBehaviour
{
    public Vector3 shotDir;
    public int hogekiCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hogekiCount <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += shotDir;
    }

    public void Shot(Vector3 vector, int num)
    {
        shotDir = vector;
        hogekiCount = num;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                VibrationMng.ShortVibration();
                collision.GetComponent<Enemy>().Bom();
                break;

            case "Wall":
                shotDir.x = shotDir.x * -1;
                break;

            case "Tori":
                collision.gameObject.SetActive(false);
                GameSystem.instance.GetTori("Tori");
                break;

            case "ShiroTori":
                collision.gameObject.SetActive(false);
                GameSystem.instance.GetTori("ShiroTori");
                break;

            case "Cleaner":
                gameObject.SetActive(false);
                break;

            case "LiberationPower":
                GameSystem.instance.StartChototsumoshin();
                collision.gameObject.SetActive(false);
                break;
        }
        hogekiCount--;
    }
}
