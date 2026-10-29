using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace EstimatingTracker;

public sealed class MainForm : Form
{
    private readonly WebView2 webView = new() { Dock = DockStyle.Fill };

    public MainForm()
    {
        Text = "Estimating Tracker";
        Icon = new System.Drawing.Icon(@"Resources\EstimatingTracker.ico");
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        MinimumSize = new System.Drawing.Size(1000, 700);
        Controls.Add(webView);
        Load += InitializeAsync;
    }

    private async void InitializeAsync(object? sender, EventArgs e)
    {
        try
        {
            string userData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Estimating-Tracker",
                "WebView2");
            Directory.CreateDirectory(userData);

            CoreWebView2Environment environment =
                await CoreWebView2Environment.CreateAsync(null, userData);
            await webView.EnsureCoreWebView2Async(environment);

            webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView.CoreWebView2.Settings.IsStatusBarEnabled = false;
            webView.CoreWebView2.Settings.IsZoomControlEnabled = true;

            string webRoot = Path.Combine(AppContext.BaseDirectory, "wwwroot");
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "app.local",
                webRoot,
                CoreWebView2HostResourceAccessKind.DenyCors);
            webView.CoreWebView2.WebMessageReceived += (s, args) =>
            {
                string message = args.TryGetWebMessageAsString();

                if (message.StartsWith("BID_NOTIFICATION|") ||
                    message.StartsWith("RFI_NOTIFICATION|") ||
                    message.StartsWith("TODO_NOTIFICATION|"))
                {
                    string[] parts = message.Split(
                        new[] { '|' },
                        3
                    );

                    if (parts.Length == 3)
                    {
                        MessageBox.Show(
                            parts[2],
                            parts[1],
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            };
            webView.CoreWebView2.Navigate("https://app.local/index.html");
        }
        catch (WebView2RuntimeNotFoundException)
        {
            MessageBox.Show(
                "Microsoft Edge WebView2 Runtime is required. Install the Evergreen WebView2 Runtime and reopen the app.",
                "WebView2 Runtime Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }
}
