using OpenQA.Selenium.Edge;
using System;
using System.Diagnostics;

namespace EdgeDriverTestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            const int firstPort = 3200;
            // var hostProcess = Start("WebViewHostTest.exe", firstPort.ToString());
            //var secondHostProcess = Start("WebViewHostTest.exe", 3201.ToString());

            EdgeDriver edgeDriver = StartEdgeDriver(9342);

            PlayWithWindow(edgeDriver);

            edgeDriver.Quit();
            //hostProcess.Kill();
        }

        private static void PlayWithWindow(EdgeDriver edgeDriver)
        {
            var pageSurce = edgeDriver.PageSource;
            //IWebElement firstNameControl = edgeDriver.FindElementById("firstname");
           // string firstNameValue = firstNameControl.GetProperty("value");
            //Console.WriteLine("Firstname: " + firstNameValue);

            //IWebElement textArea = edgeDriver.FindElementByTagName("textarea");
            //string textAreaText = textArea.Text;
            //Console.WriteLine("TextArea: " + textAreaText);

            var screenshot = edgeDriver.GetScreenshot();
            //screenshot.SaveAsFile("TestScreenshot.png", ScreenshotImageFormat.Png);

            //IWebElement button = edgeDriver.FindElementByTagName("button");
            //button.Click();
        }

        private static EdgeDriver StartEdgeDriver(int remoteDebuggingPort)
        {
            try
            {
                EdgeOptions options = new EdgeOptions { DebuggerAddress = $"localhost:{remoteDebuggingPort}"};
                options.UseWebView= true;
                var driver =  new EdgeDriver(options);

                var pageSurce = driver.PageSource;
                return driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private static Process Start(string app, string arguments)
        {
            var wpfIntegrationProcess = new Process
            {
                StartInfo = new ProcessStartInfo(app, arguments)
            };
            wpfIntegrationProcess.Start();
            //  wpfIntegrationProcess.WaitForInputIdle();

            //while (wpfIntegrationProcess.MainWindowHandle == IntPtr.Zero && !wpfIntegrationProcess.HasExited)
            //{
            //    Thread.Yield();
            //}

            if (wpfIntegrationProcess.HasExited)
            {
                throw new Exception($"TestHost process ended unexpectedly. Started with arguments: \"{arguments}\"");
            }

            return wpfIntegrationProcess;
        }
    }
}
