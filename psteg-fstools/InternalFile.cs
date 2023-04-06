using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

using psteg.Crypto;

namespace psteg_fstools {
    public sealed class InternalFile : IDisposable{
        public IntPtr Handle { get; private set; }
        public static int BlockSize { get; set; } = 4096;

        public InternalFile(string path, bool read = false) {
            IntPtr h = IntPtr.Zero;
            h = Internals.CreateFileW(path, read ? 0x01 : 0x80, 0x3, IntPtr.Zero, 3, 0, IntPtr.Zero);
            if (h == IntPtr.Subtract(IntPtr.Zero, 1))
                throw new Exception("Access failed, code " + Convert.ToString(Marshal.GetLastWin32Error(), 16));
            Handle = h;
        }

        public InternalFile(string path, string stream) {
            IntPtr h = IntPtr.Zero;
            h = Internals.CreateFileW(path+":"+stream, 0x02, 0x3, IntPtr.Zero, 2, 0, IntPtr.Zero);
            if (h == IntPtr.Subtract(IntPtr.Zero, 1))
                throw new Exception("Access failed, code " + Convert.ToString(Marshal.GetLastWin32Error(), 16));
            Handle = h;
        }

        public void CopyFrom(Stream s) {
            byte[] buff = new byte[BlockSize];
            FileStream outfs = new FileStream(new SafeFileHandle(Handle, false), FileAccess.Write);

            s.CopyTo(outfs);

            outfs.Close();
            outfs.Dispose();
        }

        public void Decrypt(FileStream dest, Encryption e) {
            FileStream infs = new FileStream(new SafeFileHandle(Handle, false), FileAccess.Read);

            Stream d = e.Decrypt(infs);

            infs.CopyTo(dest);

            infs.Close();
            infs.Dispose();

            d.Close();
            d.Dispose();
        }

        public static void DeleteStream(string path) {
            if (!Internals.DeleteFileW(path))
                throw new Exception("Access failed, code " + Convert.ToString(Marshal.GetLastWin32Error(), 16));
        }

        public Tuple<string[], long[]> ListStreams() {
            byte[] buff = new byte[64*1024]; //no way to get real size : - |
            GCHandle gchandle = GCHandle.Alloc(buff, GCHandleType.Pinned);
            Internals.IO_STATUS_BLOCK block = new Internals.IO_STATUS_BLOCK();
            uint ntstatus = 
                Internals.NtQueryInformationFile(Handle, ref block, gchandle.AddrOfPinnedObject(), (uint)buff.Length, Internals.FileInformationClass.FileStreamInformation);
            gchandle.Free();

            if (ntstatus == 0xC000000DU)
                throw new Exception("Selected file is not on an NTFS formatted filesystem"); //non-NTFS FS
            else if (ntstatus != 0)
                throw new Exception("Failed to read stream information with NTSTATUS 0x" + ntstatus.ToString("X8"));

            List<Tuple<string, long>> s = new List<Tuple<string,long>>();
            int totalOffset = 0;
            Internals.FILE_STREAM_INFORMATION fsInformation;
            do {
                fsInformation = new Internals.FILE_STREAM_INFORMATION(buff, totalOffset);
                totalOffset += (int)fsInformation.NextEntryOffset;
                s.Add(new Tuple<string, long>(fsInformation.StreamName, fsInformation.StreamSize));
            } while (fsInformation.NextEntryOffset > 0);

            string[] names = new string[s.Count];
            long[] sizes = new long[s.Count];
            for (int i = 0; i < s.Count; i++) {
                names[i] = s[i].Item1;
                sizes[i] = s[i].Item2;
            }


            return new Tuple<string[], long[]>(names, sizes);
        }

        public void Dispose() =>
            Internals.NtClose(Handle);
    }
}
