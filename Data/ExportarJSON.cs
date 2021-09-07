using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorEBC.Data
{
    public class ExportarJSON
    {
        public static string DataTableToJSONWithJSONNet(DataTable tabela, string caminho )
            {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(tabela,Formatting.Indented);

            System.IO.File.WriteAllText(caminho, JSONString);
            return JSONString;
        }
    }
}
