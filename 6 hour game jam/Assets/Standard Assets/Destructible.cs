﻿using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	public BuildingTypes BuildingType;

	public void DestroyThis(){

		ScoreKeeper.Instance.DestroyBuilding(BuildingType);

	}
}
