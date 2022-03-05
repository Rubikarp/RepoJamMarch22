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
            var x = Random.Range(0, 360);
            var value =(Mathf.PI / 180) * x;
            var range = Random.Range(10, 15);
            var _ennemy = Instantiate(ennemies[index].type, new Vector2(Mathf.Cos(value), Mathf.Sin(value))* range, Quaternion.identity);
            _ennemy.GetComponent<Ennemy>().Init(this, index, sushiPos);
        }
        else
            StopCoroutine(SpawnEnnemy(index));
        yield return new WaitForSeconds(2*(index+1));
        StartCoroutine(SpawnEnnemy(index));
    }
}
[System.Serializable]
public class ennemiesPool{
   public  GameObject type;
   public  int maxNumber;
}