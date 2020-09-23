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
			.SetSubject("Subject goes here").SetText("I'm playing Donors and I'm helping collecting donations to Lebanon. It's your turn now download and play and help!")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

	}
	private IEnumerator ShareFromGameOver()
	{
		yield return new WaitForEndOfFrame();

		new NativeShare().SetText("")
			.SetSubject("Subject goes here").SetText("I scored " + GameManagerTwo.score.ToString()+ "playing Donors and helped collecting donations to Lebanon through advertising revenue.It's your turn now download and play and help!")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

	}
	public void OpenDirectDonation()
	{
		Application.OpenURL("https://supportlrc.app/");
	}
	public void FacebookLink()
	{
		Application.OpenURL("https://www.facebook.com/SuperNova-Games-Non-profit-103180424846331");
	}
	public void InstagramLink()
	{
		Application.OpenURL("https://www.instagram.com/super_nova_gs/?hl=en");
	}
	public void YoutubeLink()
	{
		Application.OpenURL("https://www.youtube.com/channel/UCh3P21qv9cLkhesaMclYp1Q/featured");
	}
	public void PatreonLink()
	{
		Application.OpenURL("https://www.patreon.com/HusseinAttie");
	}
	public void TweeterLink()
	{
		Application.OpenURL("https://twitter.com/HusseinAttie931");
	}
}
