using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Vector3 randomPosition;
    public GameObject enemyPrefab;
    Text scoreTxt;
    private static int score = 0;

    float elapsed;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.Find("score").GetComponent<Text>();
        elapsed = 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsed += Time.fixedDeltaTime;

        if(elapsed > 8) {
            randomPosition = new Vector3(Random.Range(-3,3), 0, Random.Range(-3,3));
            navMeshAgent.SetDestination(randomPosition);

            elapsed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet"){
            Destroy(collision.gameObject, 0.1f);
            Destroy(gameObject, 0.1f);

            score++;
            scoreTxt.text = "Score: " + score;

            randomPosition = new Vector3(Random.Range(-3,3), 0, Random.Range(-3,3));
            GameObject go = Instantiate(enemyPrefab);
            go.transform.position = randomPosition;
        }
    }

}
