using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfResponsiveMultiplataform.Command;

namespace WpfResponsiveMultiplataform.ViewModel;
public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public static void CloseApp(object? obj)
    {
        MainWindow? win = obj as MainWindow;
        win?.Close();
    }


    private ICommand? _closeCommand;

    public ICommand CloseAppCommand
    {
        get
        {
            _closeCommand ??= new RelayCommand(CloseApp);
            return _closeCommand;
        }
    }

    public static void MaxApp(object? obj)
    {
        MainWindow? win = obj as MainWindow;

        if (win?.WindowState == WindowState.Normal)
        {
            win.WindowState = WindowState.Maximized;
        }
        else if (win?.WindowState == WindowState.Maximized)
        {
            win.WindowState = WindowState.Normal;
        }
    }

    private ICommand? _maxCommand;
    public ICommand MaxAppCommand
    {
        get
        {
            _maxCommand ??= new RelayCommand(MaxApp);
            return _maxCommand;
        }
    }

    public void CloseMenu()
    {
        IsPanelVisible = false;
    }

    public void ShowMenu()
    {
        IsPanelVisible = true;
    }

    private ICommand? _showMenuCommand;

    public ICommand ShowMenuCommand
    {
        get
        {
            _showMenuCommand ??= new RelayCommand(p => ShowMenu());
            return _showMenuCommand;
        }
    }

    private ICommand? _closeMenuCommand;

    public ICommand CloseMenuCommand
    {
        get
        {
            _closeMenuCommand ??= new RelayCommand(p => CloseMenu());
            return _closeMenuCommand;
        }
    }

    private bool _isPanelVisible = false;
    public bool IsPanelVisible
    {
        get
        {
            return _isPanelVisible;
        }
        set
        {
            _isPanelVisible = value;
            OnPropertyChanged("IsPanelVisible");
        }
    }
}