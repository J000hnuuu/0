using System;
using System.IO;
using System.Text;
using System.Xml;

class Program
{
    static void Main()
    {
        // Fragmento binario proporcionado
        byte[] binaryData = Encoding.Default.GetBytes("bplist00Ô\x01\x02\x03\x04\x05\x06\x07X$versionY$archiverT$topX$objects\x12\x01† _NSKeyedArchiverÑ\x08\troot€£U$nullÒ\rZNS.objectsV$class \x80\x02\x8d\x12\x13\x14\x15Z$classnameX$classes^NSMutableArray£WNSArrayXNSObject\x08$)27ILQSW]bmtuw|‡\x90Ÿ£«\x01\x01\x01\x01\x18");

        // Intentemos decodificar el fragmento binario como una lista de propiedades
        try
        {
            using (MemoryStream stream = new MemoryStream(binaryData))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    var plist = new System.Xml.Plist.PlistDocument();
                    plist.Load(reader);

                    // Accede a los datos decodificados
                    Console.WriteLine("Datos decodificados:");
                    Console.WriteLine(plist.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al decodificar: " + e.Message);
        }
    }
}
