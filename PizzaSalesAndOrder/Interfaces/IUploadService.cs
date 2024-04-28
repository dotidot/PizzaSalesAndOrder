namespace PizzaSalesAndOrder.Interfaces;

public interface IUploadService
{
    void Upload(Stream stream, string destination, string filename );
}
