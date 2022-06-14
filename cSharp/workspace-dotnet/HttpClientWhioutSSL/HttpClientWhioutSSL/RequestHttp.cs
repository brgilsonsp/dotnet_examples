using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWhioutSSL
{
    public class RequestHttp
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> DoRequest(string url, string datas, TypeHttpMethod typeHttpMethod)
        {
            try
            {
                HttpContent httpContent = null;
                if (typeHttpMethod != TypeHttpMethod.GET && typeHttpMethod != TypeHttpMethod.DELETE)
                {
                    httpContent = this.BuildHttpContent(datas);
                }

                HttpResponseMessage responseMessage = await this.Execute(url, httpContent, typeHttpMethod);
                return await this.BuildReturn(responseMessage);
            }
            catch(Exception e)
            {
                return $"Exception: {e.Message}";
            }
        }

        private async Task<HttpResponseMessage> Execute(string url, HttpContent httpContent, TypeHttpMethod typeHttpMethod)
        {
            IgnoreCertificate();

            switch (typeHttpMethod)
            {
                case TypeHttpMethod.POST:
                    return await httpClient.PostAsync(url, httpContent);
                case TypeHttpMethod.PUT:
                    return await httpClient.PutAsync(url, httpContent);
                case TypeHttpMethod.DELETE:
                    return await httpClient.DeleteAsync(url);
                case TypeHttpMethod.GET:
                    return await httpClient.GetAsync(url);
                default:
                    return null;
            }
        }

        private StringContent BuildHttpContent(string objectJson)
        {
            return new StringContent(objectJson, Encoding.UTF8, "application/json");
        }

        private async Task<string> BuildReturn(HttpResponseMessage message)
        {
            string headerResponse = HeaderInString(message.Headers);
            string retornoContentJson = await message.Content.ReadAsStringAsync();

            string msgReturn = $"Response: {Environment.NewLine}";
            msgReturn += $"Code: {message.StatusCode}{Environment.NewLine}";
            msgReturn += $"ReasonPhrase: {message.ReasonPhrase}{Environment.NewLine}";
            msgReturn += $"Headers: {headerResponse}{Environment.NewLine}";
            msgReturn += $"Data: {retornoContentJson}{Environment.NewLine}";

            return msgReturn;
        }

        private string HeaderInString(HttpHeaders Headers)
        {
            string header = "";
            foreach (KeyValuePair<string, IEnumerable<string>> head in Headers.ToList())
            {
                header += $"{Environment.NewLine} - {head.Key}";
                int sizeList = 0;
                foreach (string valueHead in head.Value.ToList())
                {
                    header += $": {valueHead}";
                    sizeList++;
                    if (head.Value.ToList().Count < sizeList)
                        header += " - ";
                }
            }
            if (String.IsNullOrWhiteSpace(header))
                header += $"{Environment.NewLine}";

            return header;
        }
        

        private static void IgnoreCertificate()
        {
            ServicePointManager.ServerCertificateValidationCallback += AcceptCertificate;
        }

        private static bool AcceptCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
