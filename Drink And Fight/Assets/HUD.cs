using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class HUD : MonoBehaviour
{


	public static HUD instance;
	[SerializeField] private List<GameObject> scoreObjects;
	[SerializeField] private List<TextMeshProUGUI> scoreTexts;
	[SerializeField] private List<Image> colorBlocks;
	[SerializeField] private List<Image> crowns;
	private int playerCount = 0;


	public void Awake()
	{
		instance = this;
		Init();
	}

	public void Init()
	{

		scoreObjects.ForEach(x => x.SetActive(false));
		crowns.ForEach(x => x.gameObject.SetActive(false));
		scoreTexts.ForEach(x => x.text = "0");
	}

	public void OnJoinPlayer(Player pl)
	{
		scoreObjects[playerCount].SetActive(true);
		colorBlocks[playerCount].color = pl.color;
		playerCount++;
	}

	
}
