using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string url = "http://www.google.com";
        [TestMethod]
        public void TestMethod1()
        {
            var httpRequestInfo = HttpWebRequest.CreateHttp(url);
            var callback = new AsyncCallback(httpResponseAvailable);
            var ar = httpRequestInfo.BeginGetResponse(callback, httpRequestInfo);
            ar.AsyncWaitHandle.WaitOne();
        }
        private static void httpResponseAvailable(IAsyncResult ar)
        {
            var httpRequestInfo = ar.AsyncState as HttpWebRequest;
            var httpResponseInfo = httpRequestInfo.EndGetResponse(ar) as HttpWebResponse;

            var responsestream = httpResponseInfo.GetResponseStream();
            using (var sr = new StreamReader(responsestream))
            {
                var webpage = sr.ReadToEnd();
            }
        }
    }
}
