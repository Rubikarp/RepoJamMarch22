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
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(SpawnEnnemy(0));
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
            var x = Random.Range(10, 15);
            var y = Random.Range(10, 15);
            var xSigne = Random.Range(0, 2);
            if (xSigne == 1)
                x *= -1;
            var ySigne = Random.Range(0, 2);
            if (ySigne == 1)
                y *= -1;
            var _ennemy = Instantiate(ennemies[index].type, new Vector2(x, y), Quaternion.identity);
            _ennemy.GetComponent<Ennemy>().Init(this, index, sushiPos);
        }
        else
            StopCoroutine(SpawnEnnemy(index));
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnEnnemy(index));
    }
}
[System.Serializable]
public class ennemiesPool{
   public  GameObject type;
   public  int maxNumber;
}