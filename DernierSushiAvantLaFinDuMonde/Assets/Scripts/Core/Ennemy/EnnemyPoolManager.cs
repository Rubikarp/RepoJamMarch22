using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPoolManager : MonoBehaviour
{
    public List<ennemiesPool> ennemies;
    private List<int> currentNumber;
    public Transform sushiPos;

    // Start is called before the first frame update
    void Start()
    {
        currentNumber = new List<int>();
        for (int i = 0; i < ennemies.Count; i++)
        {
            currentNumber.Add(0);
        }
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(SpawnEnnemy(0));
        }
        for (int i = 1; i < ennemies.Capacity; i++)
        {
            StartCoroutine(SpawnEnnemy(i));
        }
    }
    public void OnDeath(int index)
    {
        currentNumber[index]--;
        StartCoroutine(SpawnEnnemy(index));
    }

    IEnumerator SpawnEnnemy(int index)
    {
        if (ennemies[index].maxNumber > currentNumber[index])
        {
            currentNumber[index]++;
            var angle = Random.Range(0, 2*Mathf.PI);
            var value = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
            value.x = value.x * 1.8f;
            var range = Random.Range(9, 12);
            var _ennemy = Instantiate(ennemies[index].type, value * range, Quaternion.identity, transform);
            _ennemy.GetComponent<Ennemy>().Init(this, index, sushiPos);
        }
        else
            StopCoroutine(SpawnEnnemy(index));
        yield return new WaitForSeconds(1.5f*(index+1));
        StartCoroutine(SpawnEnnemy(index));
    }
    public void EndOFtTheWorld()
    {
        for (int i = 0; i < 3; i++)
        {
            ennemies[i].maxNumber *= 15;
        }
        for (int i = 0; i < 15; i++)
        {
            for (int x = 0; x < 3; x++)
            {
                StartCoroutine(SpawnEnnemy(x));
            }
        }
        
    }
}
[System.Serializable]
public class ennemiesPool{
   public  GameObject type;
   public  int maxNumber;
}