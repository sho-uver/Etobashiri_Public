using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 生成するキャラクターのプレハブ
    public GameObject characterPrefab;

    // キャラクターを生成する位置のリスト
    public Transform[] spawnPoints;

    // 生成間隔（秒）
    public float spawnInterval = 3f;

    // タイマー
    private float timer;

    void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // 一定時間経過したらキャラクターを生成
        if (timer >= spawnInterval)
        {
            SpawnCharacter();
            timer = 0f; // タイマーをリセット
        }
    }

    void SpawnCharacter()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("Spawn points are not set!");
            return;
        }

        // ランダムな生成位置を選択
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // キャラクターを生成
        Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log($"Character spawned at {spawnPoint.position}");
    }
}