﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RequestOrgs : MonoBehaviour
{
    private string url = "https://backend.gonzagatours.app/api/organizations";
    Text testText;
    public Button DatabaseButton;
    public List<string> orgNames = new List<string>();
    public List<Dropdown.OptionData> orgDropdownNames = new List<Dropdown.OptionData>();
    public UnityWebRequest request;
    public Dropdown drop;



    public void Start()
    {
        drop = GameObject.Find("OrganizationDropdown").GetComponent<Dropdown>();
        drop.ClearOptions();
        StartCoroutine(GetText());
    }

    public IEnumerator GetText()
    {
        request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Authentication", "Api-Key b49aad95-4493-44ff-b18a-be8bb2d1e012");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // Show results as text
            //Debug.Log(request.downloadHandler.text);
            var response = JsonConvert.DeserializeObject<OrgData>(request.downloadHandler.text);

            Dropdown.OptionData fillData = new Dropdown.OptionData();
            fillData.text = response.data[0].department;
            //orgDropdownNames.Add(fillData);
            drop.options.Add(fillData);
            fillData.text = response.data[1].department;
            //orgDropdownNames.Add(fillData);
            drop.options.Add(fillData);
            fillData.text = response.data[2].department;
            //orgDropdownNames.Add(fillData);
            drop.options.Add(fillData);

            Debug.Log(response.data[0].department);
            Debug.Log(response.data[1].department);
            Debug.Log(response.data[2].department);


            populateOrgsDropdown(orgDropdownNames);
        }
    }

    public void populateOrgsDropdown(List<Dropdown.OptionData> orgDropdownNames)
    {

    }


}