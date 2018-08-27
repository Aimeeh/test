using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utilities
{
    public class SerializerDataToClient
    {
        public static string GetResponseJsonString(bool hasValue, object data)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ser.MaxJsonLength = Int32.MaxValue;
            string jsonString = ser.Serialize(new
            {
                hasValue = hasValue.ToString().ToLower(),
                data = data
            });
            return jsonString;
        }

        public static string GetResponseJsonString(bool hasValue, object data, object line)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ser.MaxJsonLength = Int32.MaxValue;
            string jsonString = ser.Serialize(new
            {
                hasValue = hasValue.ToString().ToLower(),
                data = data,
                line = line
            });
            return jsonString;
        }

        public static string GetResponseJsonString(bool hasValue, object data, bool showinfo)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ser.MaxJsonLength = Int32.MaxValue;
            string jsonString = ser.Serialize(new
            {
                hasValue = hasValue.ToString().ToLower(),
                data = data,
                showinfo = showinfo.ToString().ToLower(),
            });
            return jsonString;
        }
    }
}
