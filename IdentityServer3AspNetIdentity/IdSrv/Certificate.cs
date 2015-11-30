using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace IdentityServer3AspNetIdentity.IdSrv
{
    static class Certificate
    {
        public static X509Certificate2 Get()
        {
            var resourceName = ConfigurationManager.AppSettings["certificateResourceName"];
            var certificatePassword = ConfigurationManager.AppSettings["certificatePassword"];

            var assembly = typeof(Certificate).Assembly;
            string[] names = assembly.GetManifestResourceNames();
            foreach (var name in names)
            {
                Console.WriteLine(name);
                bool isSame = name.Equals(resourceName);
                Console.WriteLine(isSame);
            }

            // Make sure to set build action of pfx file to Embedded Resource
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                return new X509Certificate2(ReadStream(stream), certificatePassword);
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}