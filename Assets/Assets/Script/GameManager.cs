using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public bool playerDie = false;
    public float pipeTime = 2f;
    public float pipeMin = -0.5f;
    public float pipeMax = 0.5f;
    static public int score = 0;
    static public int bestScore = 0;
    public Text ScoreText;

    public GameObject pipePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(PipeStart());
    }

    IEnumerator PipeStart()
    {
        do
        {
            Instantiate(pipePrefab,
                new Vector3(3.5f, Random.Range(pipeMin, pipeMax), 0),
                Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(pipeTime);
        } while (!playerDie);
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
