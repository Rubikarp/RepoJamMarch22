using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiBarBehavior : MonoBehaviour
{
    int numberOfRecepeServed=0;
    public int maxIngredientNumber;
    private Recepe currentRecepe;
    public List<Ingredient> ingredients;
    public List<Image> recepeUI;
    public Image fillAmount;
    public GameObject imageBackgroundLife;
    private PNJ waitingPnj;
    private float currentWaitingTIme;
    public Image orderImage;
    public void CreatRecepe(PNJ pnj)
    {
        List<Ingredient> myIngredient = new List<Ingredient>();
        orderImage.enabled = true;
        imageBackgroundLife.SetActive(true);
        for (int i = 0; i < numberOfRecepeServed/2 +3; i++)
        {
            myIngredient.Add(ingredients[Random.Range(0, ingredients.Count)]);
            recepeUI[i].gameObject.SetActive(true);
            recepeUI[i].sprite = myIngredient[myIngredient.Count - 1].ingredientSprite;
        }
        fillAmount.gameObject.SetActive(true);
        currentRecepe = new Recepe(myIngredient);
        waitingPnj = pnj;
        currentWaitingTIme = 0;
        StartCoroutine(WaitForDeath(waitingPnj.waitingTime));
    }
    public bool  ServeRecepe(List<Ingredient> playerList)
    {
        if (numberOfRecepeServed / 2 < maxIngredientNumber)
            numberOfRecepeServed++;
        if (currentRecepe != null)
            if (currentRecepe.CheckRecepe(playerList))
            {
                HideRecepe();
                waitingPnj.Move(1);
                waitingPnj = null;
                ScoreSystem.instance.AddScore(500);
                return true;
            }

        return false;
    }
    private void Update()
    {
        if (waitingPnj)
        {
            currentWaitingTIme += Time.deltaTime;
            fillAmount.fillAmount = 1 - currentWaitingTIme / waitingPnj.waitingTime;
        }
    }
    public void HideRecepe()
    {
        imageBackgroundLife.SetActive(false);
        orderImage.enabled = false;
        currentRecepe = null;
        foreach (var ui in recepeUI)
        {
            ui.gameObject.SetActive(false);
        }
        fillAmount.gameObject.SetActive(false);
    }

    IEnumerator WaitForDeath(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        Death();
    }
    public void Death()
    {
        HideRecepe();
        if (!waitingPnj)
            return;
        waitingPnj.Death();
        waitingPnj = null;
    }

    public void ShowRecepe()
    {

    }
}
