using System;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace LeanCLR.BuildProcessors
{

    internal class SetupIl2CppEnv : IPreprocessBuildWithReport
    {
        public int callbackOrder => 1;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!Settings.EnableForCurrentBuildTarget)
            {
                Environment.SetEnvironmentVariable("UNITY_IL2CPP_PATH", "");
                return;
            }
            var installerController = new LocalInstaller();
            if (!installerController.HasInstalledToLocal())
            {
                throw new Exception($"Please install LeanCLR first.");
            }
            string runtimeDir = Settings.LocalIl2CppPath;
            Environment.SetEnvironmentVariable("UNITY_IL2CPP_PATH", runtimeDir);
            Debug.Log($"[SetupIl2CppEnv] set UNITY_IL2CPP_PATH='{runtimeDir}'");
        }
    }
}
