using System;
using System.Runtime.InteropServices;

namespace iQuest.StarFiles.WinApi
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(string lpFileName, DesiredAccess dwDesiredAccess, ShareMode dwShareMode, IntPtr lpSecurityAttributes, CreationDisposition dwCreationDisposition, FlagsAndAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32", SetLastError = true)]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool ReadFile(IntPtr hFile, byte[] aBuffer, uint cbToRead, ref uint cbThatWereRead, IntPtr pOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFile(IntPtr hFile, byte[] aBuffer, uint cbToWrite, ref uint cbThatWereWritten, IntPtr pOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SetFilePointer(IntPtr hFile, int lDistanceToMove, IntPtr lpDistanceToMoveHigh, MoveMethod dwMoveMethod);
    }
}