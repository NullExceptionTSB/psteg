using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace psteg_fstools {
    public static class Internals {
        
        [DllImport("ntdll.dll")]
        public static extern int NtQueryInformationFile(IntPtr FileHandle, IntPtr IoStatusBlock, IntPtr FileInformation, FileInformationClass FileInformationClass);
        [DllImport("ntdll.dll")]
        public static extern int NtOpenFile(out IntPtr pFileHandle, int DesiredAccess, IntPtr ObjectAttributes, IntPtr IoStatusBlock, int ShareAccess, int OpenOptions);
        [DllImport("ntdll.dll")]
        public static extern int NtClose(IntPtr Handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateFileW(string filename, int access, int share, IntPtr securityAttributes, int creationDisposition,int flagsAndAttributes, IntPtr templateFile);

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
    }
}
