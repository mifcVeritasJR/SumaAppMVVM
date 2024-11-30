using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SumaAppMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _numero1;
        private string _numero2;
        private string _resultado;

        public string Numero1
        {
            get => _numero1;
            set
            {
                _numero1 = value;
                OnPropertyChanged(nameof(Numero1));
            }
        }

        public string Numero2
        {
            get => _numero2;
            set
            {
                _numero2 = value;
                OnPropertyChanged(nameof(Numero2));
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public ICommand SumarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public MainViewModel()
        {
            SumarCommand = new Command(Sumar);
            LimpiarCommand = new Command(Limpiar);
        }

        private void Sumar()
        {
            if (string.IsNullOrWhiteSpace(Numero1) || string.IsNullOrWhiteSpace(Numero2))
            {
                Resultado = "Error: Ambos campos son obligatorios.";
                return;
            }

            if (double.TryParse(Numero1, out double num1) && double.TryParse(Numero2, out double num2))
            {
                Resultado = $"Resultado: {num1 + num2}";
            }
            else
            {
                Resultado = "Error: Ingrese números válidos.";
            }
        }

        private void Limpiar()
        {
            Numero1 = string.Empty;
            Numero2 = string.Empty;
            Resultado = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}