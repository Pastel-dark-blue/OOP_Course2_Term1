namespace Laba13
{
    class Program
    {
        static void Main(string[] args)
        {
            KSADiskInfo.driveInfoString();
            KSADirInfo.dirInfoString(@"D:\open_server\OpenServer\domains\chainsaw");

            KSAFileInfo.fileInfoString(@"D:\ООП_2к_1с\Laba13\devilman_crybaby.txt");

            KSAFileManager.KSAInspect(@"C:\");
            KSAFileManager.KSAExtensionCopy(@"D:\ООП_2к_1с\Laba13");
            KSAFileManager.MakeArchive();
            
            KSALog.ActionsForTheLastHour();
        }
    }
}
