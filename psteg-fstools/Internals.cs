using System;
using System.Runtime.InteropServices;
using System.Text;

namespace psteg_fstools {
    public static class Internals {
        
        [DllImport("ntdll.dll")]
        public static extern int NtQueryInformationFile(IntPtr FileHandle, ref IO_STATUS_BLOCK IoStatusBlock, IntPtr FileInformation, uint Length, FileInformationClass FileInformationClass);
        [DllImport("ntdll.dll")]
        public static extern int NtClose(IntPtr Handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateFileW(string filename, int access, int share, IntPtr securityAttributes, int creationDisposition,int flagsAndAttributes, IntPtr templateFile);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool DeleteFileW(string lpFileName);

        public enum FileInformationClass {
            FileDirectoryInformation = 1,
            FileFullDirectoryInformation,
            FileBothDirectoryInformation,
            FileBasicInformation,
            FileStandardInformation,
            FileInternalInformation,
            FileEaInformation,
            FileAccessInformation,
            FileNameInformation,
            FileRenameInformation,
            FileLinkInformation,
            FileNamesInformation,
            FileDispositionInformation,
            FilePositionInformation,
            FileFullEaInformation,
            FileModeInformation = 16,
            FileAlignmentInformation,
            FileAllInformation,
            FileAllocationInformation,
            FileEndOfFileInformation,
            FileAlternateNameInformation,
            FileStreamInformation,
            FilePipeInformation,
            FilePipeLocalInformation,
            FilePipeRemoteInformation,
            FileMailslotQueryInformation,
            FileMailslotSetInformation,
            FileCompressionInformation,
            FileObjectIdInformation,
            FileCompletionInformation,
            FileMoveClusterInformation,
            FileQuotaInformation,
            FileReparsePointInformation,
            FileNetworkOpenInformation,
            FileAttributeTagInformation,
            FileTrackingInformation,
            FileIdBothDirectoryInformation,
            FileIdFullDirectoryInformation,
            FileValidDataLengthInformation,
            FileShortNameInformation,
            FileHardLinkInformation = 46
        }
        public struct FILE_STREAM_INFORMATION {
            public uint NextEntryOffset;
            public uint StreamNameLength;
            public long StreamSize;
            public long StreamAllocationSize;
            public string StreamName;

            public FILE_STREAM_INFORMATION(byte[] buffer, int offset) {
                NextEntryOffset = BitConverter.ToUInt32(buffer, offset);
                StreamNameLength = BitConverter.ToUInt32(buffer, offset + 4);
                StreamSize = BitConverter.ToInt64(buffer, offset + 8);
                StreamAllocationSize = BitConverter.ToInt64(buffer, offset + 16);
                StreamName = Encoding.Unicode.GetString(buffer, offset+24, (int)StreamNameLength);
            }
        }
        public struct IO_STATUS_BLOCK {
            public uint status;
            public ulong information;
        }

    }
}
