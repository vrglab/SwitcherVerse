using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Pathfinding;

public class RunManager : PersistantSingleton<RunManager>
{
    public bool TestMode;

    public Run CurrentRun
    {
        get
        {
            return _currentRun;
        }
    }

    public Settings CurrentSettings
    {
        get
        {
            return CurrentRun.Settings;
        }
    }

    public RunData CurrentRunData
    {
        get
        {
            return CurrentRun.RunData;
        }
    }

    private Run _currentRun;
    private List<Run> _currentRunList = new List<Run>();

    private static string run_save_path = Application.streamingAssetsPath + "/Runs/";

    public void Awake()
    {
        base.Awake();
        if (TestMode)
        {
            CreateNewRun();
        }
        if (Directory.Exists(run_save_path))
        {
            foreach (var directory in Directory.GetDirectories(run_save_path))
            {
                RunData data = LoadRunFromDirectory(directory);
                Settings settings = new Settings();
                settings.Load(data.location);
                Run run = new Run()
                {
                    RunData = data,
                    Settings = settings
                };

                _currentRunList.Add(run);
            }

            SetRun(0);
        }
        else
        {
            Directory.CreateDirectory(run_save_path);
        }
    }

    public void OnDestroy()
    {
        CurrentRun.Save();
    }

    public void SetRun(int run)
    {
        _currentRun = _currentRunList[run];
    }

    public Run CreateNewRun()
    {
        Run run = new Run();
        run.RunData = new RunData();
        run.Settings = new Settings();  

        run.RunData.id = Guid.NewGuid();
        run.RunData.location = run_save_path + run.RunData.id;
        run.RunData.name = "New World";
        run.Settings.SetSetting("dm_state", DimensionalState.TwoD);

        Directory.CreateDirectory(run.RunData.location);

        string file = run.RunData.location + "/runData.bin";
        FileStream fileS = null;
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            if (!File.Exists(file))
            {
                fileS = File.Create(file);
            }
            else
            {
                fileS = File.OpenWrite(file);
            }
            formatter.Serialize(fileS, run.RunData);
        }
        catch (Exception e)
        {
            fileS.Close();
            Debug.LogException(e);
        }
        fileS.Close();

        _currentRunList.Add(run);
        return run;
    }

    private RunData LoadRunFromDirectory(string path)
    {
        RunData runData = new RunData();
        string file = path + "/runData.bin";
        if (File.Exists(file))
        {
            FileStream fileS = File.OpenRead(file);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                runData = (RunData)formatter.Deserialize(fileS);
            }
            catch (Exception e)
            {
                fileS.Close();
                Debug.LogException(e);
            }
            fileS.Close();
        }
        return runData;
    }

}


public struct Run
{
    public RunData RunData;
    public Settings Settings;

    public void Save()
    {
        Settings.Save(RunData.location);
    }
}

[Serializable]
public struct RunData
{
    public Guid id;
    public string name; 
    public string location;
}
