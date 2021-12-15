using System.IO;

namespace NaturaApp.Common.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
        bool UploadPhoto(MemoryStream stream, string folder, string name);
    }
}
