using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    //creating 2 abstruct method
    void loadData(GameData data);
    void saveData(ref GameData data);
}
