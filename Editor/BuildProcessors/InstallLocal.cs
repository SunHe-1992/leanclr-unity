using System;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace LeanCLR.BuildProcessors
{
    internal class InstallLocal : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!Settings.EnableForCurrentBuildTarget)
            {
                return;
            }
            var installerController = new LocalInstaller();
            if (!installerController.HasInstalledToLocal())
            {
                Debug.LogWarning($"[CheckSettings] LeanCLR is not installed, start install LeanCLR..");
                installerController.InstallLocal();
            }
            if (!installerController.HasInstalledToLocal())
            {
                throw new Exception($"[CheckSettings] Failed to install LeanCLR, please check the log for details.");
            }
        }
    }
}
