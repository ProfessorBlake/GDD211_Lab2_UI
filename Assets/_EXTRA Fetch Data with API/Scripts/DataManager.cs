using JetBrains.Annotations;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    public class DataManager : MonoBehaviour
    {
        [Header("API")]
        [Tooltip("URL that points to JSON data")] 
        [SerializeField] private string url = "https://api.weather.gov/points/41.3829,-72.9077";

		[Header("UI")]
		[SerializeField] private TMP_Text text;
		[SerializeField] private Transform periodContainer;
		[SerializeField] private PeriodButton periodButtonPrefab;

		[Header("Data")]
		[SerializeField] private Periods periods;

		private void Start()
		{
			GetData();
		}

		public void GetData()
        {
			StartCoroutine(GetJsonData());
        }

		private IEnumerator GetJsonData()
		{
			using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
			{
				yield return webRequest.SendWebRequest();

				if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
				{
					Debug.LogError("Error: " + webRequest.error);
				}
				else
				{
					string jsonString = webRequest.downloadHandler.text;
					//Debug.Log("Received: " + jsonString);
					string[] substr = jsonString.Split("\"periods\": [");
					substr[1] = "{\"periods\": [" + substr[1].Substring(0, substr[1].Length - 2);
					Debug.Log(substr[1]);
					periods = JsonUtility.FromJson<Periods>(substr[1]);

					for (int i = 0; i < 5; i++)
					{
						PeriodButton p = Instantiate(periodButtonPrefab, periodContainer);
						p.Init(periods.periods[i]);
					}
				}
			}
		}
	}
}

[Serializable]
public class Periods
{
	public Period[] periods;
}

[Serializable]
public class Period	
{
	public int number;
	public string name;
	public DateTime startTime;
	public DateTime endTime;
	public bool isDaytime;
	public int temperature;
	public string temperatureUnit;
	public string windSpeed;
	public string windDirection;
	public string icon;
	public string shortForecast;
	public string detailedForecast;
}