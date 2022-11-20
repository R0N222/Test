using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.power;
public class GameManager : MonoBehaviour
{
	public static List<Player> players = new List<Player>();

	[SerializeField] private List<Level> levels;

	[SerializeField] private List<ActivePower> activePowers;

	private int currentLevel = 0;

	private int spawnIndex = 0;


	public static GameManager instance;
	private int currentlyAlive;

	public void Awake()
	{
		instance = this;
	}
	private void Start()
	{

		StartRound();
	}



	public void OnPlayerConnect(Player pl)
	{
		players.Add(pl);
		pl.transform.position =  levels[currentLevel].spawnPoints[spawnIndex++ % levels[currentLevel].spawnPoints.Count].position;
		currentlyAlive++;
		CamManager.instance.Add(pl.transform);
		HUD.instance.OnJoinPlayer(pl);
	}

	public void StartRound()
	{

		Debug.Log("start Round");
		currentlyAlive = players.Count;
		SelectRandomLevel();

		players.ForEach(x => ResetPlayers(x));

	}

	public void ResetPlayers(Player p)
	{
		p.Reset(activePowers[UnityEngine.Random.Range(0,activePowers.Count)]);
		p.transform.position = levels[currentLevel].spawnPoints[spawnIndex++ % levels[currentLevel].spawnPoints.Count].position;
		CamManager.instance.Add(p.transform);

	}



	public void OnDeath(Player pl)
	{
		currentlyAlive--;
		CamManager.instance.Remove(pl.transform);

		if (currentlyAlive < 2)
		{
			EndRound();

		}
	}


	private void EndRound()
	{
		// 

		StartRound();
	}

	public static void ExecuteAfterTime(Action act, float time)
	{
		instance.StartCoroutine(instance.WaitAndExecute(act, time));
	}


	public IEnumerator WaitAndExecute(Action act, float time)
	{
		yield return new WaitForSeconds(time);
		act();
	}

	#region Levels
	private void SelectRandomLevel()
	{
		currentLevel = UnityEngine.Random.Range(0, levels.Count);

		for (int i = 0; i < levels.Count; i++)
		{
			levels[i].gameObject.SetActive(currentLevel == i);
			
		}
	}



	#endregion

}
