using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayCompleteAction : IDisposable
{
    public const int LeaveSceneTimeout = 5;

    private ForceSelector forceSelector;
    private StageStatistics stats;
    private IDisposable sub;

    public GameplayCompleteAction(StageStatistics stats, ForceSelector forceSelector)
    {
        this.stats = stats;
        this.forceSelector = forceSelector;
    }

    public void Completed()
    {
        if (stats.Completed) return;

        stats.Completed = true;
        forceSelector.IsActive = false;

        sub = Observable.Timer(TimeSpan.FromSeconds(LeaveSceneTimeout)).First().Subscribe(_ =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }

    public void Dispose()
    {
        if (sub != null)
        {
            sub.Dispose();
            sub = null;
        }
    }

}
