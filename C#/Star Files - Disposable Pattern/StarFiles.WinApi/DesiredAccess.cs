using System;

namespace iQuest.StarFiles.WinApi
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/secauthz/access-mask
    /// </summary>
    [Flags]
    public enum DesiredAccess : uint
    {
        GENERIC_READ = 0x80000000,
        GENERIC_WRITE = 0x40000000
    }
}