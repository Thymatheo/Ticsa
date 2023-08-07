using System.Diagnostics;
using System.IO;

namespace Ticsa {
    public static class FileManager {
        private const string BASE_DIRECTORY = "Data";
        public const string DELIVERYCOUPON_DIRECTORY = "DeliveryCoupon";
        public static string Copy(string filePath, string directory) {

            FileInfo file = new(filePath);
            using FileStream destination = File.Create(Path.Combine(GetDirectoryPath(directory), file.Name));
            using FileStream source = File.Open(file.FullName, FileMode.Open);
            source.CopyTo(destination);
            return file.Name;
        }
        static FileManager() {
            DirectoryInfo baseDirectory = new(BASE_DIRECTORY);
            if (!baseDirectory.Exists) baseDirectory.Create();
            DirectoryInfo deliveryCouponDirectory = new(GetDirectoryPath(DELIVERYCOUPON_DIRECTORY));
            if (!deliveryCouponDirectory.Exists) deliveryCouponDirectory.Create();
        }

        private static string GetDirectoryPath(string subDir) =>
            Path.Combine(BASE_DIRECTORY, subDir);

        internal static void Open(string subDirectory, string? filePath) {
            if (filePath == null) return;
            else Process.Start(new ProcessStartInfo(Path.Combine(BASE_DIRECTORY, subDirectory, filePath)) {
                UseShellExecute = true
            });
        }
    }
}
