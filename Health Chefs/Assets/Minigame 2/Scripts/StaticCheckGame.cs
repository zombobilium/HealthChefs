using UnityEngine;
using System.Collections;

public static class StaticCheckGame {

	private static bool gameWin = true;
	private static bool gameEnded = false;
	private static int slotsChecked = 0;
	private static int roundNumber = 0;

	public static int getRoundNumber()
	{
		return roundNumber;
	}

	public static void incRoundNumber()
	{
		roundNumber++;
	}

	public static int getSlotsChecked()
	{
		return slotsChecked;
	}

	public static void incSlotsChecked()
	{
		slotsChecked++;
	}

	public static void setGameWinFalse() 
	{
		gameWin = false;
	}

	public static void setGameWinTrue() 
	{
		gameWin = true;
	}

	public static bool getGameWin()
	{
		return gameWin;
	}

	public static bool getGameEnded() 
	{
		return gameEnded;
	} 

	public static void setGameEndedTrue()
	{
		gameEnded = true;
	}

	public static void setGameEndedFalse()
	{
		gameEnded = false;
	}

	public static void reset()
	{
		gameWin = true;
		gameEnded = false;
		slotsChecked = 0;
		roundNumber = 0;
	}

	public static void nextRound()
	{
		gameWin = true;
		gameEnded = false;
		slotsChecked = 0;
	}
}
