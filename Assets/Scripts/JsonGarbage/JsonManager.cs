using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class BuildingPriceManager
{
	public string country;
	public int earthPrice;
	public int buildingPrice;
	public int villaPrice;
	public int hotelPrice;

	public BuildingPriceManager(string Country, int EarthPrice, int BuildingPrice, int VillaPrice, int HotelPrice)
	{
		country = Country;
		earthPrice = EarthPrice;
		buildingPrice = BuildingPrice;
		villaPrice = VillaPrice;
		hotelPrice = HotelPrice;
	}
}

public class JsonManager : MonoBehaviour
{
	public List<BuildingPriceManager> buildingPrice = new List<BuildingPriceManager>();

	private void Start()
	{
		buildingPrice.Add(new BuildingPriceManager("타이베이", 2000, 10000, 90000, 250000));
		buildingPrice.Add(new BuildingPriceManager("열쇠", 0, 0, 0, 0));
		buildingPrice.Add(new BuildingPriceManager("베이징", 4000, 20000, 180000, 450000));
		buildingPrice.Add(new BuildingPriceManager("마닐라", 4000, 20000, 180000, 450000));
		buildingPrice.Add(new BuildingPriceManager("제주도", 0, 0, 0, 0));
		buildingPrice.Add(new BuildingPriceManager("싱가포르", 6000, 30000, 270000, 550000));
		buildingPrice.Add(new BuildingPriceManager("열쇠", 0, 0, 0, 0));
		buildingPrice.Add(new BuildingPriceManager("카이로", 6000, 30000, 270000, 550000));
		buildingPrice.Add(new BuildingPriceManager("이스탄불", 8000, 40000, 300000, 600000));
		buildingPrice.Add(new BuildingPriceManager("사회복지", 0, 0, 0, 0));
		buildingPrice.Add(new BuildingPriceManager("아테네", 10000, 50000, 450000, 750000));
	}

	public void Save()
	{
		Debug.Log("저장");

		JsonData buildingJson = JsonMapper.ToJson(buildingPrice);

		File.WriteAllText(Application.dataPath + "/Resources/BuildingPrice.json", buildingJson.ToString());
	}

	public void Load()
	{
		Debug.Log("불러오기");

		string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/BuildingPrice.json");

		Debug.Log(Jsonstring);
		JsonData buildingData = JsonMapper.ToObject(Jsonstring);

		for(int i=0; i< buildingData.Count;i++)
		{
			Debug.Log(buildingData[i]["country"].ToString());
			Debug.Log(buildingData[i]["earthPrice"].ToString());
			Debug.Log(buildingData[i]["buildingPrice"].ToString());
			Debug.Log(buildingData[i]["villaPrice"].ToString());
			Debug.Log(buildingData[i]["hotelPrice"].ToString());
		}
	}
}
