using PizzaSalesAndOrder.Interfaces;

namespace PizzaSalesAndOrder.Services;

public class UploadService : IUploadService
{
    public void Upload(Stream stream, string destination, string filename)
    {
        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }

        var path = Path.Combine(destination, filename);

        using(var fileStream = new FileStream(path, FileMode.OpenOrCreate))
        {
            stream.CopyTo(fileStream);
        }
    }
}
