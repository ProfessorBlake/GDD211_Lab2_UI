using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PeriodButton : MonoBehaviour
{
	[SerializeField] private Image backgroundImage;
	[SerializeField] private Color coldColor;
	[SerializeField] private Color hotColor;
	[SerializeField] private TMP_Text txt;
	[SerializeField] private Image iconImage;

	private Period data;

	public void Init(Period newData)
	{
		data = newData;

		backgroundImage.color = Color.Lerp(coldColor, hotColor, data.temperature / 80f);
		txt.text = $"{data.name}\n{data.temperature}*F";

		StartCoroutine(DownloadImage(data.icon));
	}

	private IEnumerator DownloadImage(string url)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
		{
			Debug.LogError("Error: " + request.error);
		}
		else
		{
			Texture2D tex = DownloadHandlerTexture.GetContent(request);

			if (iconImage != null)
			{
				Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
				iconImage.sprite = sprite;
				iconImage.color = Color.white;
			}
		}
	}
}
