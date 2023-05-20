using Forum.Enums.File;

namespace Forum.Service.Abstracts;

public interface IImageProfile
{
    ImageType ImageType { get; }
    string Folder { get; }
    int Width { get; }
    int Height { get; }
    int MaxSizeBytes { get; }

    IEnumerable<string> AllowedExtensions { get; }
}