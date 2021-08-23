using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using Newtonsoft.Json;
using UnityEngine.UI;

public class PriceManagers
{
	public string country;
	public int earthPrice;
	public int buildingPrice;
	public int villaPrice;
	public int hotelPrice;

	public PriceManagers(string Country, int EarthPrice, int BuildingPrice, int VillaPrice, int HotelPrice)
	{
		this.country = Country;
		this.earthPrice = EarthPrice;
		this.buildingPrice = BuildingPrice;
		this.villaPrice = VillaPrice;
		this.hotelPrice = HotelPrice;
	}
}
public class JsonManagers : MonoBehaviour
{
	[SerializeField] private Text earthPrice;
	[SerializeField] private Text building;
	[SerializeField] private Text villa;
	[SerializeField] private Text hotel;

	[SerializeField] private Text specialName;
	[SerializeField] private Text specialPrice;

	public static JsonManagers Instance { get; private set; }

	private void Start()
	{
		Instance ??= this;
	}

	public void Load(int x)
	{
		string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/BuildingJson.json");
		JsonData buildingData = JsonMapper.ToObject(Jsonstring);

		var number = x-1;

		if (number == 4 || number == 14 || number == 24)
		{
			SpecialPrice(number, buildingData);
		}

		else
		{
			Price(number, buildingData);
		}
	}

	public void Load2(int x)
	{
		string json = File.ReadAllText(Application.dataPath + "/Resources/BuildingJson.json");
		var buildingData = JsonConvert.DeserializeObject<Build[]>(json);

		for (int i = 0; i < buildingData.Length; ++i)
		{
			if (i == 4 || i == 14 || i == 24)
			{
				SpecialPrice2(i, buildingData[i]);
			}
			else
			{
				Price2(i, buildingData[i]);
			}
		}
	}

	void Price(int a, JsonData Data)
	{
		earthPrice.text = Data[a]["Land"].ToString();
		building.text = Data[a]["Building"].ToString();
		villa.text = Data[a]["Villa"].ToString();
		hotel.text = Data[a]["Hotel"].ToString();

		Debug.Log(Data[a]["Country"].ToString());
		Debug.Log(Data[a]["Land"].ToString());
		Debug.Log(Data[a]["Building"].ToString());
	}

	private void Price2(int idx, Build data)
	{
		this.earthPrice.text = data.Land.ToString();
		this.building.text = data.Building.ToString();
		this.villa.text = data.Villa.ToString();
		this.hotel.text = data.Hotel.ToString();
	}

	void SpecialPrice(int a, JsonData Data)
	{
		specialName.text = Data[a]["Country"].ToString();
		specialPrice.text = Data[a]["Land"].ToString();

		Debug.Log(Data[a]["Country"].ToString());
		Debug.Log(Data[a]["Land"].ToString());
	}

	private void SpecialPrice2(int idx, Build data)
	{
		this.specialName.text = data.Country.ToString();
		this.specialPrice.text = data.Land.ToString();
	}
}