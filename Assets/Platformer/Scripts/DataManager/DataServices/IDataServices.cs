using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IDataServices
{
    public UserData GetData();
    public void SetData(UserData data);
}
