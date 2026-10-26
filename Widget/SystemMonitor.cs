using System;
using System.Runtime.InteropServices;

namespace Widget
{
    public static class SystemMonitor
    {
        [StructLayout(LayoutKind.Sequential)]
        private class MemoryStatus
        {
            public uint Length;
            public uint MemoryLoad;
            public ulong TotalPhys;
            public ulong AvailablePhys;
            public ulong TotalPageFile;
            public ulong AvailablePageFile;
            public ulong TotalVirtual;
            public ulong AvailableVirtual;
            public ulong AvailableExtendedVirtual;

            public MemoryStatus()
            {
                Length = (uint)Marshal.SizeOf<MemoryStatus>();
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx(
            [In, Out] MemoryStatus buffer);

        public static int GetRamUsage()
        {
            MemoryStatus status = new MemoryStatus();

            if (GlobalMemoryStatusEx(status))
            {
                return (int)status.MemoryLoad;
            }

            return -1;
        }
    }
}