using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    private static IDataServices dataService;
    private static UserData userData;

    public static UserData UserData { get => userData; set => userData = value; }

    public static void GetDataServices()
    {
        dataService = new EditorDataServices();
    }

    public static void GetUserData()
    {
        userData = dataService.GetData();
    }

    public static void SetUserData()
    {
        dataService.SetData(userData);
    }

}