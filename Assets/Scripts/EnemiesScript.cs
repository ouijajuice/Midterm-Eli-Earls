using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesScript : MonoBehaviour
{
    public Transform enemy;
    public int rows = 5;
    public int cols = 11;
    public float spacing;
    public Vector3 initialPosition { get; private set; }
    public Vector3 diRection = Vector2.right;
    public float speed;

    public Transform missilePrefab;
    public float missileSpawnRate = 1f;

    private void Awake()
    {
        initialPosition = transform.position;

        CreateEnemyGrid();
    }

    private void CreateEnemyGrid()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = spacing * (this.cols - 1);
            float height = spacing * (this.rows - 1);
            Vector3 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPos = new Vector3(centering.x, centering.y + (row * spacing), 0.0f);

            for (int col = 0; col < this.cols; col++)
            {
                Instantiate(enemy, this.transform);
                Vector3 position = rowPos;
                position.x += col * spacing;
                enemy.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), missileSpawnRate, missileSpawnRate);
    }

    private void MissileAttack()
    {
        int amountAlive = GetAliveCount();

        if (amountAlive == 0)
        {
            return;
        }

        foreach (Transform enemy in transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1f / (float)amountAlive))
            {
                Instantiate(missilePrefab, enemy.position, Quaternion.identity);
                break;
            }
        }
    }

    private void Update()
    {
        int totalCount = rows * cols;
        int amountAlive = GetAliveCount();
        int amountKilled = totalCount - amountAlive;
        float percentKilled = (float)amountKilled / (float)totalCount;

        this.transform.position += diRection * this.speed * Time.deltaTime;

        Vector3 leftBorder = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightBorder = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (diRection == Vector3.right && enemy.position.x >= (rightBorder.x - 0.2f))
            {
                GoDown();
            } else if (diRection == Vector3.left && enemy.position.x <= (leftBorder.x + 0.2f))
            {
                GoDown();
            }
        }
        if (GetAliveCount() <= 0)
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }

    private void GoDown()
    {
        diRection.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 0.15f;
        this.transform.position = position;
    }

    public int GetAliveCount()
    {
        int count = 0;

        foreach (Transform enemy in transform)
        {
            if (enemy.gameObject.activeSelf)
            {
                count++;
            }
        }

        return count;
    }
}
