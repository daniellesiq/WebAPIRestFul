using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Util
{
    /*Classe responsável por fazer requisições á API - WEBAPI*/
    public class WebAPI
    {
        /*Incluir URI da API*/
        public static string URI = "";        
        public static string TOKEN = "123yew45jn3gik3k43h3";

        public static string RequestGET_DELETE(string metodo, string parametro, string tipo)
        {            
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo + "/" + parametro);
            request.Headers.Add("Token", TOKEN);
            request.Method = tipo;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
        
        public static string RequestGET(string metodo, string parametro)
        {
            return RequestGET_DELETE(metodo,parametro,"GET");
        }

        public static string RequestDELETE(string metodo, string parametro)
        {
            return RequestGET_DELETE(metodo, parametro, "DELETE");
        }


        public static string RequestPOST_PUT(string metodo, string jsonData, string tipo)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = tipo;
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string RequestPOST(string metodo, string jsonData)
        {
            return RequestPOST_PUT(metodo, jsonData, "POST");
        }

        public static string RequestPUT(string metodo, string jsonData)
        {     
            return RequestPOST_PUT(metodo, jsonData, "PUT");
        }        
    }
}
