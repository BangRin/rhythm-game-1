using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerfectFX : MonoBehaviour
{

    private int destValue = 54;

    public Text targetText;

    private void OnEnable()
    {
        targetText.enabled = true;
        targetText.fontSize = 1;

        StopCoroutine(TweenAnimation());
        StartCoroutine(TweenAnimation());
    }
    private void OnDisable()
    {
        targetText.enabled = false;
        StopCoroutine(TweenAnimation());
        targetText.fontSize = 1;
    }


    IEnumerator TweenAnimation()
    {

        while(targetText.fontSize <= 54)
        {
            yield return new WaitForSeconds(0.01f);
            targetText.fontSize += 4;
        }


        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

}
