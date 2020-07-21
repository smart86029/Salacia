using System;
using System.Runtime.InteropServices;

namespace Salacia.Common.Utilities
{
    public static class GuidUtility
    {
        private const int RPC_S_OK = 0;

        public static Guid NewGuid()
        {
            var rpcStatus = UuidCreateSequential(out var guid);
            if (rpcStatus != RPC_S_OK)
                throw new ApplicationException("UuidCreateSequential failed: " + rpcStatus);

            var bytes = guid.ToByteArray();
            Array.Reverse(bytes, 0, 4);
            Array.Reverse(bytes, 4, 2);
            Array.Reverse(bytes, 6, 2);

            return new Guid(bytes);
        }

        [DllImport("rpcrt4.dll", SetLastError = true)]
        private static extern int UuidCreateSequential(out Guid guid);
    }
}