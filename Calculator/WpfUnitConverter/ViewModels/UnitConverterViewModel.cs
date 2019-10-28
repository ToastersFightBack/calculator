using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace WpfUnitConverter.ViewModels
{
    
    public class UnitConverterViewModel : ObservableObject
    {
        public ICommand Solve {get; set;}
        private double _result;
       
        
        public double Operand { get; set; }
        public double Operand2 { get; set; }
        public string OperandUnit { get; set; }

        public string ResultUnit { get; set; }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public List<string> Units { get; set; }

        private List<string> BuildOutUnitComboBoxSource()
        {
            return new List<string>() { "+", "-", "*", "/", "Sin", "Cos", "Tan", "SqRT", "^", "%" };
        }
        private void PerformCalculation(object obj)
        {
           // inches
            if (OperandUnit== "+")
            {
                Result = Operand + Operand2;
            }
            else if (OperandUnit == "-")
                {
                Result = Operand - Operand2;
                }
            else if (OperandUnit == "*" )
            {
                Result = Operand * Operand2;
            }
            else if (OperandUnit == "/" )
            {
                Result = Operand / Operand2;
            }
            else if (OperandUnit == "Sin" )
            {
                Result = Math.Sin(Operand);
                
            }
            else if (OperandUnit == "Cos" )
            {
                Result = Math.Cos(Operand);
            }
            else if (OperandUnit == "Tan")
            {
                Result = Math.Tan(Operand);
            }
            else if (OperandUnit == "SqRT" )
            {
                Result = Math.Sqrt(Operand);
            }
            else if (OperandUnit == "^")
            {
                Result = Math.Pow(Operand, Operand2);
            }
            else if (OperandUnit == "%" )
            {
                   Result = Operand * (Operand2 / 100); ;
            }


        }

        public UnitConverterViewModel()
        {
            //Operand = 44; //value to confirm binding of property
            Units = BuildOutUnitComboBoxSource();
            Solve = new RelayCommand(new Action<object>(PerformCalculation));
        }
    }

}

