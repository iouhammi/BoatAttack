using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BoatAttack;

public class CountDownUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
	[SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip countClip;
    [SerializeField] private AudioClip goClip;
	public void Begin(int steps)
    {
        StartCoroutine(PlayCountDownRoutine(steps));
    }

    IEnumerator PlayCountDownRoutine(int steps)
    {
        text.enabled = true;
        while(steps >= 0)
        {
            Debug.Log("CountDown: " + steps);
            text.text = steps == 0 ? "GO" : steps.ToString();
			audioSource.PlayOneShot(steps == 0 ? goClip : countClip);
			yield return new WaitForSeconds(1);
            steps--;
        }
        text.enabled = false;
    }
}
