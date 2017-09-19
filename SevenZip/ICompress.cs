using System.IO;

namespace Compress
{
    public interface ICompress
    {
        int LocalFilesCount();

        string Filename(int i);
        ulong? LocalHeader(int i);
        ulong UncompressedSize(int i);
        byte[] CRC32(int i);
        ZipReturn FileStatus(int i);
        byte[] MD5(int i);
        byte[] SHA1(int i);


        ZipOpenType ZipOpen { get; }

        ZipReturn ZipFileOpen(string newFilename, bool readHeaders=true);

        ZipReturn ZipFileOpen(byte[] zipFileBytes);
        void ZipFileClose();

        ZipReturn ZipFileOpenReadStream(int index, out Stream stream, out ulong streamSize);
        ZipReturn ZipFileOpenWriteStream(bool raw, bool trrntzip, string filename, ulong uncompressedSize, ushort compressionMethod, out System.IO.Stream stream);
        ZipReturn ZipFileCloseReadStream();
        void DeepScan();

        string ZipFilename { get; }

        void ZipFileAddDirectory();

        ZipReturn ZipFileCreate(string newFilename);
        ZipReturn ZipFileCloseWriteStream(byte[] crc32);
        ZipReturn ZipFileRollBack();
        void ZipFileCloseFailed();

    }
}
