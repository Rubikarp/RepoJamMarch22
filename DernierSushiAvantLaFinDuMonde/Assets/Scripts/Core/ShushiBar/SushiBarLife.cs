using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SushiBarLife : MonoBehaviour
{
    public int maxLife;
    private float currentLife;
    public float timeBeforRegen;
    private float timer;
    private bool isHealing;
    public Image LifeBar;
    public ScoreDisplay GameOver;
    private void Start()
    {
        currentLife = maxLife;
        
    }
    private void Update()
    {
        if (timer < timeBeforRegen)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Healing();
        }
    }
    public void TakeDamage(int damage)
    {
        isHealing = false;
        currentLife-= damage;
        LifeBar.gameObject.SetActive(true);
        LifeBar.fillAmount = currentLife / (float)maxLife;
        timer = 0;
        if(currentLife == 0)
        {
            Time.timeScale = 0;
            GameOver.ShowEnd();
        }
    }
    private void Healing()
    {
        if (!isHealing && currentLife != maxLife)
        {
            isHealing = true;
            StartCoroutine(Heal());
        }
    }
    IEnumerator Heal()
    {
        yield return new WaitForSeconds(0.1f);
        currentLife ++ ;
        LifeBar.fillAmount = currentLife / (float)maxLife;
        if (isHealing && currentLife < maxLife)
            StartCoroutine(Heal());
        else if(currentLife >= maxLife)
        {
            isHealing = false;
            currentLife = maxLife;
            LifeBar.gameObject.SetActive(false);
        }
    }
}
