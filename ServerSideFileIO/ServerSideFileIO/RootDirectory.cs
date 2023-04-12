namespace ServerSideFileIO
{
    public class RootDirectory
    {
        public static string? root = Directory.GetParent(       // Debug
            Directory.GetCurrentDirectory())                    // net6.0
            .Parent                                             // bin
            .Parent                                             // project folder
            .ToString();
    }
}
