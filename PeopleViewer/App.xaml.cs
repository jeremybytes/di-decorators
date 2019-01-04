using PeopleViewer.Presentation;
using PersonReader.CSV;
using PersonReader.Decorators;
using PersonReader.Service;
using System.Windows;
using System.Windows.Threading;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Application.Current.DispatcherUnhandledException += UnhandledException;
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private void UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unable to process request. Please try again later.");
            e.Handled = true;
        }

        private static void ComposeObjects()
        {
            var reader = new ServiceReader();
            var retryReader = new RetryReader(reader);
            var loggingReader = new ExceptionLoggingReader(retryReader);
            var cachingReader = new CachingReader(loggingReader);
            var viewModel = new PeopleReaderViewModel(cachingReader);
            Application.Current.MainWindow = new MainWindow(viewModel);
        }
    }
}
