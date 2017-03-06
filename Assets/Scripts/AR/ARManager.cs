using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;

public class ARManager : MonoBehaviour {
    void Start() {
        ScriptEventSystem.Instance.OnSetMode += Instance_OnSetMode;
        ScriptEventSystem.Instance.OnGoToLocation += LoadLocation;
        LoadLocation(ScriptEventSystem.Instance.CurrentLocation);
    }

    private void LoadLocation(Location l) {
        if (l != null && l.ARDataset != null && l.ARDataset.Length > 0) {
            LoadDataSet(l.ARDataset);
        }
    }

    private void Instance_OnSetMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR)
            UnloadAllDatasets();
    }

    private void UnloadAllDatasets() {
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (objectTracker == null)
            return;
        List<DataSet> datasets = new List<DataSet>();
        foreach (var t in objectTracker.GetActiveDataSets()) {
            datasets.Add(t);
        }
        foreach(var d in datasets) {
            objectTracker.DeactivateDataSet(d);
        }
    }

    private void UnloadDataSet(string path) {
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        foreach (var t in objectTracker.GetActiveDataSets()) {
            if (t.Path == GetFullPath(path)) {
                Debug.Log("Deactivating dataset " + path + ".");
                objectTracker.DeactivateDataSet(t);
                return;
            }
        }
        Debug.Log("" + path + " is not an active dataset.");
    }

    private string GetFullPath(string path) {
        return "QCAR/" + path + ".xml";
    }

    // Load and activate a data set at the given path.
    private bool LoadDataSet(string dataSetPath) {
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

        foreach (var t in objectTracker.GetActiveDataSets()) {
            if (t.Path == GetFullPath(dataSetPath)) {
                Debug.Log("Data set " + dataSetPath + " is already active.");
                return true;
            }
        }

        foreach (var t in objectTracker.GetDataSets()) {
            if (t.Path == GetFullPath(dataSetPath)) {
                Debug.Log("Data set " + dataSetPath + " is already loaded. Activating dataset.");
                objectTracker.ActivateDataSet(t);
                return true;
            }
        }

        // Check if the data set exists at the given path.
        if (!DataSet.Exists(dataSetPath)) {
            Debug.LogError("Data set " + dataSetPath + " does not exist.");
            return false;
        }

        // Request an ImageTracker instance from the TrackerManager.

        // Create a new empty data set.
        DataSet dataSet = objectTracker.CreateDataSet();

        // Load the data set from the given path.
        if (!dataSet.Load(dataSetPath)) {
            Debug.LogError("Failed to load data set " + dataSetPath + ".");
            return false;
        }

        // (Optional) Activate the data set.
        Debug.Log("Data set " + dataSetPath + " is not loaded. Loading and activating dataset.");
        objectTracker.ActivateDataSet(dataSet);

        return true;
    }
}
