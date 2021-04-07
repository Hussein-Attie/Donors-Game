using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share : MonoBehaviour
{
	public void ShareButtonClick()
	{
		StartCoroutine(ShareFromMenu());
	}
	public void ShareButtonClickEnd()
	{
		StartCoroutine(ShareFromGameOver());
	}
	private IEnumerator ShareFromMenu()
	{
		yield return new WaitForEndOfFrame();

		new NativeShare().SetText("")
			.SetSubject("Subject goes here").SetText("I'm playing Donors. Download and play with me ")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

	}
	private IEnumerator ShareFromGameOver()
	{
		yield return new WaitForEndOfFrame();

		new NativeShare().SetText("")
			.SetSubject("Subject goes here").SetText("I scored " + GameManagerTwo.score.ToString()+ "playing Donors.Can you beat my score?")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

	}
	public void OpenDirectDonation()
	{
		Application.OpenURL("http://www.iemoji.com/view/emoji/56/smileys-people/thumbs-up");
	}
	public void FacebookLink()
	{
		Application.OpenURL("http://www.iemoji.com/view/emoji/56/smileys-people/thumbs-up");
	}
	public void InstagramLink()
	{
		Application.OpenURL("http://www.iemoji.com/view/emoji/56/smileys-people/thumbs-up");
	}
	public void YoutubeLink()
	{
		Application.OpenURL("http://www.iemoji.com/view/emoji/56/smileys-people/thumbs-up");
	}
	public void PatreonLink()
	{
		Application.OpenURL("http://www.iemoji.com/view/emoji/56/smileys-people/thumbs-up");
	}
	public void TweeterLink()
	{
		Application.OpenURL("http://www.iemoji.com/view/emoji/56/smileys-people/thumbs-up");
	}
}
