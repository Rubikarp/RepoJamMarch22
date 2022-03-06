using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJManager : MonoBehaviour
{
    public float maxWaitingTime = 30;
    public float minWaitingTime=15 ;
    public GameObject pnj;
    private List<PNJ> pnjs = new List<PNJ>();
    public List<Transform> spawnPoints;
    private PNJ hungryPnj;
    private void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var _pnjGO = Instantiate(pnj, spawnPoints[i].position, Quaternion.identity, transform);
            _pnjGO.GetComponent<PNJ>().Init(this, Random.Range(minWaitingTime, maxWaitingTime),  spawnPoints[i].gameObject);
            pnjs.Add(_pnjGO.GetComponent<PNJ>());
        }
        StartCoroutine(WaitToSelectAnother());
    }
    
    private void Select()
    {
            var rand = Random.Range(0, pnjs.Count);
            hungryPnj = pnjs[rand];
            hungryPnj.Move(-1);
    }

    public void Unselect()
    {
        hungryPnj = null;
        StartCoroutine(WaitToSelectAnother());
    }
    public void DeathOfPnj(PNJ pnj)
    {
        pnjs.Remove(pnj);
        hungryPnj = null;
        StartCoroutine(WaitToSelectAnother());
    }
    private IEnumerator WaitToSelectAnother()
    {
        yield return new WaitForSeconds(2);
        Select();
    }
    // generate pnj, InitThem, call them randomly one per one to get food,
}
