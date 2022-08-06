using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExcelConverter
{
    public class JsonConverter
    {
        private static JObject ToJObject(List<string> nameList, List<string> valList)
        {
            JObject jobj = new JObject();
            for (int i = 0; i < nameList.Count; i++)
                jobj.Add(nameList[i], valList[i]);
            return jobj;
        }

        public static void ToJsonFile(string path, List<List<string>> data)
        {
            JArray jarr = new JArray();
            for (int i = 2; i < data.Count; i++)
                jarr.Add(ToJObject(data[0], data[i]));

            string json = JsonConvert.SerializeObject(jarr);

            File.WriteAllText(path, json);
        }
    }
}
