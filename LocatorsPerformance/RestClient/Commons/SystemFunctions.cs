using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Hackpro.LocatorsPerformance.RestClient.Commons
{
    [ExcludeFromCodeCoverage]
    public static class SystemFunctions
    {
        private static readonly string _localKey = "HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
        private static readonly string _machineKey = "HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
        private static readonly string _machineKey64 = "HKLM:\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
        private static readonly RegistryKey _keys = Registry.LocalMachine.OpenSubKey(_localKey) ??
                                                    Registry.LocalMachine.OpenSubKey(_machineKey) ??
                                                    Registry.LocalMachine.OpenSubKey(_machineKey64);

        public static bool IsSoftwareInstalled(string softwareName)
        {
            if (_keys == null)
                return false;

            try
            {
                return _keys.GetSubKeyNames()
                    .Select(keyName => _keys.OpenSubKey(keyName))
                    .Select(subkey => subkey.GetValue("DisplayName") as string)
                    .Any(displayName => displayName != null && displayName.Contains(softwareName));
            }
            catch
            {
                return false;
            }
        }

        public static string GetOperaBinaryPath()
        {
            if (IsSoftwareInstalled("Opera"))
            {
                try
                {
                    var registryKey = _keys.GetSubKeyNames()
                        .Select(keyName => _keys.OpenSubKey(keyName))
                        .Select(subkey => subkey.GetValue("DisplayName") as string)
                        .FirstOrDefault(displayName => displayName != null && displayName.Contains("Opera"));
                    return registryKey.ToString();
                    // return registryKey.InstallLocation + registryKey.DisplayVersion;
                }
                catch
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}
