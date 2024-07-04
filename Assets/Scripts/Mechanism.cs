using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mechanism : MonoBehaviour
{
    System.DateTime date = new System.DateTime(2022, 3, 15, 9, 0, 0);

    public int money = 0;
    public int popularity = 1;

    [SerializeField] List<Text> stats;
    
    int target_m = 1250;
    int target_p = 100;

    float timer, spawnTimer = 0f;

    public GameObject npcPrefab;
    public float spawnDelay;
    public Vector3 spawnPoint = new Vector3(10f, 0f, 10f);

    void Start()
    {
        Time.timeScale = 1;

        npcPrefab.GetComponent<CustomerMovement>().setting = gameObject.GetComponent<Mechanism>();
        //InvokeRepeating("SpawnNPC", 0f, Random.Range(2f, 5f));
    }

    void Update()
    {
        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");

        stats[0].text = date.ToString("HH:mm");
        stats[1].text = date.ToString("dd/MM/yyyy");
        stats[2].text = target_p.ToString();
        stats[3].text = target_m.ToString();
        stats[4].text = money.ToString();
        stats[5].text = popularity.ToString();
        stats[6].text = npcObjects.Length.ToString();

        timer = timer + Time.deltaTime;

        if (timer >= 1f)
        {
            date = date.AddMinutes(4);

            timer = 0;
        }

        spawnTimer += Time.deltaTime;
        if (date.Hour < 21)
        {
            if (spawnTimer >= Random.Range(5f, 10f))
            {
                SpawnNPC();
                spawnTimer = 0;
            }
        }
        else Time.timeScale = 0;
    }

    void SpawnNPC()
    {
        Instantiate(npcPrefab, spawnPoint, Quaternion.identity);
    }
}